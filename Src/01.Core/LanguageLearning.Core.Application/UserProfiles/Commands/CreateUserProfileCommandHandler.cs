using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.UserProfiles.Commands.DTO;
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
        CreateUserProfileCommand request,
        CancellationToken cancellationToken)
    {
        var firstName = new FirstName(request.CreateDto.FirstName);
        var lastName = new LastName(request.CreateDto.LastName);
        var age = new Age(request.CreateDto.Age);
        var gender = (GenderType)request.CreateDto.Gender;

        var hobbiesTask = _referenceDataCache.GetHobbiesAsync(cancellationToken);
        var interestsTask = _referenceDataCache.GetInterestsAsync(cancellationToken);
        var languagesTask = _referenceDataCache.GetLanguagesAsync(cancellationToken);
        var countriesTask = _referenceDataCache.GetCountriesAsync(cancellationToken);

        await Task.WhenAll(hobbiesTask, interestsTask, languagesTask, countriesTask);

        var hobbies = hobbiesTask.Result;
        var interests = interestsTask.Result;
        var languages = languagesTask.Result;
        var countries = countriesTask.Result;

        var userHobbies = hobbies.Where(q => request.CreateDto.Hobbies.Contains(q.Id)).ToList();
        var userInterests = interests.Where(q => request.CreateDto.Interests.Contains(q.Id)).ToList();
        var userNativeLanguage = languages.FirstOrDefault(l => l.Id == request.CreateDto.NativeLanguage)
                ?? throw new InvalidOperationException("Invalid native language ID.");
        var userLearningLanguage = languages.FirstOrDefault(l => l.Id == request.CreateDto.LearningLanguage)
            ?? throw new InvalidOperationException("Invalid learning language ID.");

        var countryOfOrigin = countries.FirstOrDefault(c => c.Id == request.CreateDto.CountryOfOrigin)
            ?? throw new InvalidOperationException("Invalid country of origin ID.");
        var currentCountry = countries.FirstOrDefault(c => c.Id == request.CreateDto.CurrentCountry)
            ?? throw new InvalidOperationException("Invalid current country ID.");

        ProficiencyLevel learningLanguageProficiencyLevel = (ProficiencyLevel)request.CreateDto.LearningLanguageProficiencyLevel;
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
