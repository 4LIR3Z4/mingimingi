using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.LearningJourney.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Enums;
using LanguageLearning.Core.Domain.UserProfiles.ValueObjects;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public sealed class UserProfile : BaseAggregateRoot<long>
{
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public Age Age { get; private set; } = null!;
    public GenderType Gender { get; private set; }
    public Language NativeLanguage { get; private set; } = null!;
    public Country CountryOfOrigin { get; private set; } = null!;
    public Country CurrentCountry { get; private set; } = null!;
    public ICollection<UserHobby> UserHobbies { get; private set; } = null!;
    public ICollection<UserInterest> UserInterests { get; private set; } = null!;
    public List<LanguageProficiency> LanguageProficiencies { get; private set; } = null!;
    public List<LearningGoal> LearningGoals { get; private set; } = null!;
    private UserProfile(
        long id,
        FirstName firstName,
        LastName lastName,
        Age age,
        GenderType gender,
        Language nativeLanguage,
        Country countryOfOrigin,
        Country currentCountry,
        List<UserHobby> userHobbies,
        List<LanguageProficiency> languageProficiencies,
        List<UserInterest> userInterests,
        List<LearningGoal> learningGoals
        ) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Gender = gender;
        NativeLanguage = nativeLanguage;
        UserHobbies = userHobbies;
        LanguageProficiencies = languageProficiencies;
        CountryOfOrigin = countryOfOrigin;
        CurrentCountry = currentCountry;
        UserInterests = userInterests;
        LearningGoals = learningGoals;
    }
    private UserProfile() { }
    public static UserProfile Create(
        long id,
        FirstName firstName,
        LastName lastName,
        Age age,
        GenderType gender,
        Language nativeLanguage,
        Country countryOfOrigin,
        Country currentCountry,
        List<Hobby> hobbies,
        List<Interest> interests,
        List<LanguageProficiency> languageProficiencies,
        List<LearningGoal> learningGoals
        )
    {
        var userProfile = new UserProfile
        (
            id,
            firstName,
            lastName,
            age,
            gender,
            nativeLanguage,
            countryOfOrigin,
            currentCountry,
            new List<UserHobby>(),
            languageProficiencies,
            new List<UserInterest>(),
            learningGoals
        );

        userProfile.UserHobbies = hobbies.Select(hobby => new UserHobby { UserProfile = userProfile, Hobby = hobby }).ToList();
        userProfile.UserInterests = interests.Select(interest => new UserInterest { UserProfile = userProfile, Interest = interest }).ToList();

        return userProfile;
    }


}
