using LanguageLearning.Core.Application.UserProfiles.Commands.DTO;
using LanguageLearning.Core.Application.UserProfiles.Commands;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Enums;
using LanguageLearning.Core.Domain.UserProfiles.ValueObjects;
using LanguageLearning.Core.Domain.Framework;
using LanguageLearning.AcceptanceTests.Utilities;
using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Infrastructure.IdGenerator;
using Microsoft.Extensions.DependencyInjection;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Infrastructure.Caching;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;

namespace LanguageLearning.AcceptanceTests.StepDefinitions;


[Binding]
public class NewUserOnboardingStepDefinitions
{

    private Result<CreateProfileResponse>? _commandResult;
    private CreateProfileRequest _profileRequest = null;
    private readonly IIdentityService _identityService;
    private readonly IDbContext _dbContext;
    private readonly IIdGenerator _idGenerator;
    private readonly IReferenceDataCache _referenceDataCache;
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly TimeProvider _timeProvider = TimeProvider.System;
    public NewUserOnboardingStepDefinitions()
    {

        var serviceProvider = new ServiceCollection()
            .AddScoped<IDbContext, MockDbContext>()
            .AddScoped<IIdentityService, MockIdentity>()
            .AddScoped<IIdGenerator, SnowflakeIdGenerator>()
            .AddScoped<IReferenceDataCache, ReferenceDataCache>()
            .AddScoped<ICommandDispatcher, CommandDispatcher>()
            .BuildServiceProvider();

        _identityService = serviceProvider.GetRequiredService<IIdentityService>();
        _dbContext = serviceProvider.GetRequiredService<IDbContext>();
        _idGenerator = serviceProvider.GetRequiredService<IIdGenerator>();
        _referenceDataCache = serviceProvider.GetRequiredService<IReferenceDataCache>();
        _commandDispatcher = serviceProvider.GetRequiredService<ICommandDispatcher>();
    }

    [Given("a user provides valid details:")]
    public void GivenAUserProvidesValidDetails(DataTable dataTable)
    {
        var data = dataTable.Rows
        .ToDictionary(row => row["Field"].ToString(), row => row["Value"].ToString());

        var firstName = data["FirstName"];
        var lastName = data["LastName"];
        int age = int.Parse(data["Age"]);
        //var birthDate = new Birthdate(DateTime.UtcNow.AddYears(-age));
        var gender = int.Parse(data["Gender"]);
        var nativeLanguageId = int.Parse(data["NativeLanguageId"]);
        var countryOfOrigin = int.Parse(data["CountryOfOrigin"]); // Assuming ISO code is not required
        var currentCountry = int.Parse(data["CurrentCountry"]); // Assuming ISO code is not required

        var hobbies = data["Hobbies"]
            .Split(", ")
            .Select(q => int.Parse(q))
            .ToList();

        var interests = data["Interests"]
            .Split(", ")
            .Select(q => int.Parse(q))
            .ToList();

        _profileRequest = new()
        {
            Id = _idGenerator.GenerateId(),
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            Gender = gender,
            NativeLanguage = nativeLanguageId,
            CountryOfOrigin = countryOfOrigin,
            CurrentCountry = currentCountry,
            Hobbies = hobbies,
            Interests = interests
        };
    }

    [When("the user profile is created")]
    public async void WhenTheUserProfileIsCreated()
    {
        
        var command = new CreateUserProfileCommand(_profileRequest);
        _commandResult = await _commandDispatcher.Dispatch<CreateUserProfileCommand, CreateProfileResponse>(command, CancellationToken.None);
        
    }

    [Then("the profile should be saved successfully")]
    public void ThenTheProfileShouldBeSavedSuccessfully()
    {

        // Ensure the command result is successful
        if (_commandResult == null || !_commandResult.IsSuccess)
        {
            throw new InvalidOperationException("Profile was not saved successfully.");
        }

        // Retrieve the saved user profile from the mock database context
        var savedUserProfile = _dbContext.UserProfiles.FirstOrDefault(up => up.Id == _commandResult.Value.ProfileId);

        // Ensure the user profile was saved
        if (savedUserProfile is null)
        {
            throw new InvalidOperationException("User profile was not found in the database.");
        }

        // Validate the saved user profile details
        Assert.Equal(_profileRequest.FirstName, savedUserProfile.FirstName.Value);
        Assert.Equal(_profileRequest.LastName, savedUserProfile.LastName.Value);
        Assert.Equal(_profileRequest.Age, savedUserProfile.Birthdate.GetAge());
        Assert.Equal((GenderType)_profileRequest.Gender, savedUserProfile.Gender);
        Assert.Equal(_profileRequest.NativeLanguage, savedUserProfile.NativeLanguageId);
        Assert.Equal(_profileRequest.CountryOfOrigin, savedUserProfile.CountryOfOrigin.Id);
        Assert.Equal(_profileRequest.CurrentCountry, savedUserProfile.CurrentCountry.Id);
        Assert.Equal(_profileRequest.Hobbies.Count, savedUserProfile.UserHobbies.Count);
        Assert.Equal(_profileRequest.Interests.Count, savedUserProfile.UserInterests.Count);
    }

    [Given("a user provides incomplete details:")]
    public void GivenAUserProvidesIncompleteDetails(DataTable dataTable)
    {
        throw new PendingStepException();
    }

    [When("the user profile creation is attempted")]
    public void WhenTheUserProfileCreationIsAttempted()
    {
        throw new PendingStepException();
    }

    [Then("the profile creation should fail")]
    public void ThenTheProfileCreationShouldFail()
    {
        throw new PendingStepException();
    }

    [Then("an error message {string} should be displayed")]
    public void ThenAnErrorMessageShouldBeDisplayed(string p0)
    {
        throw new PendingStepException();
    }

    [Given("a user provides invalid details:")]
    public void GivenAUserProvidesInvalidDetails(DataTable dataTable)
    {
        throw new PendingStepException();
    }
}

