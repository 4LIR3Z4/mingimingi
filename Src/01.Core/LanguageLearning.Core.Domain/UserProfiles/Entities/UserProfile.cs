using LanguageLearning.Core.Domain.UserProfiles.Enums;
using LanguageLearning.Core.Domain.UserProfiles.ValueObjects;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public sealed class UserProfile : BaseAggregateRoot<long>
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Age Age { get; private set; }
    public GenderType Gender { get; private set; }
    public Language NativeLanguage { get; private set; }
    public Country CountryOfOrigin { get; private set; }
    public Country CurrentCountry { get; private set; }
    public ICollection<UserHobby> UserHobbies { get; private set; }
    public ICollection<UserInterest> UserInterests { get; private set; }
    public List<LanguageProficiency> LanguageProficiencies { get; private set; }
    private UserProfile(
        long id,
        FirstName firstName,
        LastName lastName,
        Age age,
        GenderType gender,
        Language nativeLanguage,
        List<UserHobby> userHobbies,
        List<LanguageProficiency> languageProficiencies,
        Country countryOfOrigin,
        Country currentCountry,
        List<UserInterest> userInterests) : base(id)
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
    }
    private UserProfile() { }
    public static UserProfile Create(
        long id,
        FirstName firstName,
        LastName lastName,
        Age age,
        GenderType gender,
        Language nativeLanguage,
        List<Hobby> hobbies,
        List<LanguageProficiency> languageProficiencies,
        Country countryOfOrigin,
        Country currentCountry,
        List<Interest> interests)
    {
        var userProfile = new UserProfile
        (
            id,
            firstName,
            lastName,
            age,
            gender,
            nativeLanguage,
            new List<UserHobby>(),
            languageProficiencies,
            countryOfOrigin,
            currentCountry,
            new List<UserInterest>()
        );

        userProfile.UserHobbies = hobbies.Select(hobby => new UserHobby { UserProfile = userProfile, Hobby = hobby }).ToList();
        userProfile.UserInterests = interests.Select(interest => new UserInterest { UserProfile = userProfile, Interest = interest }).ToList();

        return userProfile;
    }
}
