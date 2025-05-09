using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile.DTO;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Enums;
using LanguageLearning.Core.Domain.UserProfiles.ValueObjects;

namespace LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile;
internal sealed class CreateUserProfileCommandHandler :
    ICommandHandler<CreateUserProfileCommand, CreateProfileResponse>
{
    private readonly IDbContext _context;
    private readonly IIdGenerator _idGenerator;
    private readonly IReferenceDataCache _referenceDataCache;
    private readonly IIdentityService _identityService;
    private readonly TimeProvider _timeProvider;
    public CreateUserProfileCommandHandler(
        IDbContext context,
        IIdGenerator idGenerator,
        IReferenceDataCache referenceDataCache,
        TimeProvider timeProvider,
        IIdentityService identityService
        )
    {
        _context = context;
        _idGenerator = idGenerator;
        _referenceDataCache = referenceDataCache;
        _timeProvider = timeProvider;
        _identityService = identityService;
    }

    public async Task<Result<CreateProfileResponse>> Handle(
        CreateUserProfileCommand command,
        CancellationToken cancellationToken)
    {
        CreateProfileRequest request = command.request;

        var firstName = new FirstName(request.FirstName);
        var lastName = new LastName(request.LastName);
        var age = new Birthdate(DateTime.UtcNow.AddYears(-request.Age));
        var gender = (GenderType)request.Gender;

        var hobbiesTask = _referenceDataCache.GetHobbiesAsync(cancellationToken);
        var interestsTask = _referenceDataCache.GetInterestsAsync(cancellationToken);
        var languagesTask = _referenceDataCache.GetLanguagesAsync(cancellationToken);
        var countriesTask = _referenceDataCache.GetCountriesAsync(cancellationToken);

        await Task.WhenAll(hobbiesTask, interestsTask, languagesTask, countriesTask);

        var hobbies = hobbiesTask.Result;
        var interests = interestsTask.Result;
        var languages = languagesTask.Result;
        var countries = countriesTask.Result;

        var userHobbies = hobbies.Where(q => request.Hobbies.Contains(q.Id)).ToList();
        var userInterests = interests.Where(q => request.Interests.Contains(q.Id)).ToList();
        var userNativeLanguage = languages.FirstOrDefault(l => l.Id == request.NativeLanguage)
                ?? throw new InvalidOperationException("Invalid native language ID.");
        var countryOfOrigin = countries.FirstOrDefault(c => c.Id == request.CountryOfOrigin)
            ?? throw new InvalidOperationException("Invalid country of origin ID.");
        var currentCountry = countries.FirstOrDefault(c => c.Id == request.CurrentCountry)
            ?? throw new InvalidOperationException("Invalid current country ID.");

        var ProfileId = _idGenerator.GenerateId();
        var userRegistrationResponse = await _identityService.RegisterAsync(new RegistrationRequest()
        {
            Email = request.FirstName,
            Password = request.LastName,
            FirstName = request.FirstName,
            LastName = request.LastName
        });
        if(userRegistrationResponse.IsFailure)
        {
            return Result.Failure<CreateProfileResponse>(userRegistrationResponse.Error);
        }
        var newUserProfile = UserProfile.Create(ProfileId,
            firstName,
            lastName,
            age,
            gender,
            userNativeLanguage.Id,
            countryOfOrigin,
            currentCountry,
            userHobbies,
            userInterests,
            userRegistrationResponse.Value.ExternalUserId
            );

        _context.UserProfiles.Add(newUserProfile);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success(newUserProfile.ToCreateProfileResponseDto());
    }


}
