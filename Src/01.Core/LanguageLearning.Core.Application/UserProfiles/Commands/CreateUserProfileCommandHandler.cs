using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.UserProfiles.Commands.DTO;
using LanguageLearning.Core.Domain.LearningJourney.Entities;
using LanguageLearning.Core.Domain.LearningJourney.Enums;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Enums;
using LanguageLearning.Core.Domain.UserProfiles.ValueObjects;
using System.Linq;

namespace LanguageLearning.Core.Application.UserProfiles.Commands;
class CreateUserProfileCommandHandler
{
    private readonly IDbContext _context;
    private readonly IIdGenerator _idGenerator;
    private readonly IReferenceDataCache _referenceDataCache;
    public CreateUserProfileCommandHandler(IDbContext context, IIdGenerator idGenerator, IReferenceDataCache referenceDataCache)
    {
        _context = context;
        _idGenerator = idGenerator;
        _referenceDataCache = referenceDataCache;
    }

    public async Task<Result<CreateProfileResponse>> Handle(
        CreateUserProfileCommand command,
        CancellationToken cancellationToken)
    {
        var firstName = new FirstName(command.request.FirstName);
        var lastName = new LastName(command.request.LastName);
        var age = new Age(command.request.Age);
        var gender = (GenderType)command.request.Gender;

        var hobbiesTask = _referenceDataCache.GetHobbiesAsync(cancellationToken);
        var interestsTask = _referenceDataCache.GetInterestsAsync(cancellationToken);
        var languagesTask = _referenceDataCache.GetLanguagesAsync(cancellationToken);
        var countriesTask = _referenceDataCache.GetCountriesAsync(cancellationToken);

        await Task.WhenAll(hobbiesTask, interestsTask, languagesTask, countriesTask);

        var hobbies = hobbiesTask.Result;
        var interests = interestsTask.Result;
        var languages = languagesTask.Result;
        var countries = countriesTask.Result;

        var userHobbies = hobbies.Where(q => command.request.Hobbies.Contains(q.Id)).ToList();
        var userInterests = interests.Where(q => command.request.Interests.Contains(q.Id)).ToList();
        var userNativeLanguage = languages.FirstOrDefault(l => l.Id == command.request.NativeLanguage)
                ?? throw new InvalidOperationException("Invalid native language ID.");
        var userLearningLanguage = languages.FirstOrDefault(l => l.Id == command.request.LearningLanguage)
            ?? throw new InvalidOperationException("Invalid learning language ID.");
        var countryOfOrigin = countries.FirstOrDefault(c => c.Id == command.request.CountryOfOrigin)
            ?? throw new InvalidOperationException("Invalid country of origin ID.");
        var currentCountry = countries.FirstOrDefault(c => c.Id == command.request.CurrentCountry)
            ?? throw new InvalidOperationException("Invalid current country ID.");

        ProficiencyLevel learningLanguageProficiencyLevel = (ProficiencyLevel)command.request.LearningLanguageProficiencyLevel;
        var languageProficienciy = LanguageProficiency.Create(
            userLearningLanguage,
            learningLanguageProficiencyLevel,
            learningLanguageProficiencyLevel,
            learningLanguageProficiencyLevel,
            learningLanguageProficiencyLevel);

        var ProfileId = _idGenerator.GenerateId();

        var newUserProfile = UserProfile.Create(ProfileId,
            firstName,
            lastName,
            age,
            gender,
            userNativeLanguage,
            userHobbies,
            new List<LanguageProficiency>() { languageProficienciy },
            countryOfOrigin,
            currentCountry,
            userInterests
            );

        _context.UserProfiles.Add(newUserProfile);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success<CreateProfileResponse>(newUserProfile.ToCreateProfileResponseDto());
    }
}
