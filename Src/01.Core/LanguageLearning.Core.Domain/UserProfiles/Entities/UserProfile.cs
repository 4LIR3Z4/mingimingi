
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
    public int NativeLanguageId { get; private set; } 
    public Country CountryOfOrigin { get; private set; } = null!;
    public Country CurrentCountry { get; private set; } = null!;
    public ICollection<UserHobby> UserHobbies { get; private set; } = null!;
    public ICollection<UserInterest> UserInterests { get; private set; } = null!;
    private UserProfile(
        long id,
        FirstName firstName,
        LastName lastName,
        Age age,
        GenderType gender,
        int nativeLanguageId,
        Country countryOfOrigin,
        Country currentCountry,
        List<UserHobby> userHobbies,
        List<UserInterest> userInterests
        ) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Gender = gender;
        NativeLanguageId = nativeLanguageId;
        UserHobbies = userHobbies;
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
        int nativeLanguageId,
        Country countryOfOrigin,
        Country currentCountry,
        List<Hobby> hobbies,
        List<Interest> interests
        )
    {
        var userProfile = new UserProfile
        (
            id,
            firstName,
            lastName,
            age,
            gender,
            nativeLanguageId,
            countryOfOrigin,
            currentCountry,
            new List<UserHobby>(),
            new List<UserInterest>()
        );

        userProfile.UserHobbies = hobbies.Select(hobby => new UserHobby { UserProfile = userProfile, Hobby = hobby }).ToList();
        userProfile.UserInterests = interests.Select(interest => new UserInterest { UserProfile = userProfile, Interest = interest }).ToList();

        return userProfile;
    }


}
