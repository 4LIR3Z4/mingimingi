using LanguageLearning.AcceptanceTests.Utilities;
using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using LanguageLearning.Core.Application.Common.Extensions;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile;
using LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile.DTO;
using LanguageLearning.Core.Domain.Framework;
using LanguageLearning.Core.Domain.UserProfiles.Enums;
using LanguageLearning.Infrastructure.Caching.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.AcceptanceTests.StepDefinitions;


[Binding]
public class NewUserOnboardingStepDefinitions
{

    private Result<CreateProfileResponse>? _commandResult;
    private CreateProfileRequest _profileRequest;
    private string _createUserProfileValidationResult = string.Empty;
    private readonly IIdentityService _identityService;
    private readonly IDbContext _dbContext;
    private readonly IIdGenerator _idGenerator;
    private readonly IReferenceDataCache _referenceDataCache;
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly TimeProvider _timeProvider = TimeProvider.System;
    public NewUserOnboardingStepDefinitions()
    {
        _profileRequest = new();
        var serviceCollection = new ServiceCollection();
        DependencyInjection.InitApplication(serviceCollection);
        CacheConfig.ConfigureCaching(serviceCollection);
        var serviceProvider = serviceCollection
            .AddScoped<IDbContext, MockDbContext>()
            .AddScoped<IIdentityService, MockIdentity>()
            .AddScoped<IIdGenerator, MockIdGenerator>()
            .AddScoped<IReferenceDataCache, MockReferenceDataCache>()
            .AddScoped<ICommandDispatcher, CommandDispatcher>()
            .AddSingleton(TimeProvider.System)
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
        GenerateUserProfile(dataTable);
    }

    private void GenerateUserProfile(DataTable dataTable)
    {
        var data = dataTable.Rows
                .ToDictionary(row => row["Field"].ToString(), row => row["Value"].ToString());

        var firstName = data.ContainsKey("FirstName") ? data["FirstName"] : string.Empty;
        var lastName = data.ContainsKey("LastName") ? data["LastName"] : string.Empty;
        int age = data.ContainsKey("Age") ? int.Parse(data["Age"]) : 0;
        var genderValue = data.ContainsKey("Gender") ? data["Gender"] : null;
        int gender = -99;
        if (!string.IsNullOrWhiteSpace(genderValue))
        {
            gender = int.Parse(genderValue);
        }

        var nativeLanguageId = data.ContainsKey("NativeLanguageId") ? int.Parse(data["NativeLanguageId"]) : 0;
        var countryOfOrigin = data.ContainsKey("CountryOfOrigin") ? int.Parse(data["CountryOfOrigin"]) : 0;
        var currentCountry = data.ContainsKey("CurrentCountry") ? int.Parse(data["CurrentCountry"]) : 0;

        var hobbies = data.ContainsKey("Hobbies") && !string.IsNullOrWhiteSpace(data["Hobbies"])
            ? data["Hobbies"].Split(", ").Select(q => int.Parse(q)).ToList()
            : new List<int>();

        var interests = data.ContainsKey("Interests") && !string.IsNullOrWhiteSpace(data["Interests"])
            ? data["Interests"].Split(", ").Select(q => int.Parse(q)).ToList()
            : new List<int>();

        _profileRequest = new()
        {
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
    public async Task WhenTheUserProfileIsCreated()
    {

        var command = new CreateUserProfileCommand(_profileRequest);
        _commandResult = await _commandDispatcher.DispatchAsync<CreateUserProfileCommand, CreateProfileResponse>
            (command, CancellationToken.None);

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
        GenerateUserProfile(dataTable);
    }

    [When("the user profile creation is attempted")]
    public async Task WhenTheUserProfileCreationIsAttempted()
    {
        var command = new CreateUserProfileCommand(_profileRequest);
        try
        {
            _commandResult = await _commandDispatcher.DispatchAsync<CreateUserProfileCommand, CreateProfileResponse>
                (command, CancellationToken.None);
        }
        catch (Exception ex)
        {

            _createUserProfileValidationResult = ((FluentValidation.ValidationException)ex).Errors.First().ErrorMessage;
        }
    }

    [Then("the profile creation should fail")]
    public void ThenTheProfileCreationShouldFail()
    {
        Assert.Null(_commandResult); // Ensure the command result is not null
        Assert.NotNull(_createUserProfileValidationResult);
        Assert.False(string.IsNullOrWhiteSpace(_createUserProfileValidationResult), "No error message was provided for the failed profile creation.");
    }

    [Then("an error message {string} should be displayed")]
    public void ThenAnErrorMessageShouldBeDisplayed(string expectedErrorMessage)
    {

        // Validate the error message
        Assert.Equal(expectedErrorMessage, _createUserProfileValidationResult);
    }

    [Given("a user provides invalid details:")]
    public void GivenAUserProvidesInvalidDetails(DataTable dataTable)
    {
        GenerateUserProfile(dataTable);
    }
}

