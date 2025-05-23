﻿using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Enums;
using LanguageLearning.Core.Domain.UserProfiles.Events;
using LanguageLearning.Core.Domain.UserProfiles.ValueObjects;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public sealed class UserProfile : BaseAggregateRoot<long>
{
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public Birthdate Birthdate { get; private set; } = null!;
    public GenderType Gender { get; private set; }
    public int NativeLanguageId { get; private set; }
    public Country CountryOfOrigin { get; private set; } = null!;
    public Country CurrentCountry { get; private set; } = null!;
    public ICollection<UserHobby> UserHobbies { get; private set; } = null!;
    public ICollection<UserInterest> UserInterests { get; private set; } = null!;
    public string IdentityUserId { get; private set; } = null!;
    private UserProfile(
        long id,
        FirstName firstName,
        LastName lastName,
        Birthdate birthdate,
        GenderType gender,
        int nativeLanguageId,
        Country countryOfOrigin,
        Country currentCountry,
        List<UserHobby> userHobbies,
        List<UserInterest> userInterests,
        string identityUserId
        ) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
        Gender = gender;
        NativeLanguageId = nativeLanguageId;
        UserHobbies = userHobbies;
        CountryOfOrigin = countryOfOrigin;
        CurrentCountry = currentCountry;
        UserInterests = userInterests;
        IdentityUserId = identityUserId;
    }
    private UserProfile() { }
    public static UserProfile Create(
        long id,
        FirstName firstName,
        LastName lastName,
        Birthdate birthdate,
        GenderType gender,
        int nativeLanguageId,
        Country countryOfOrigin,
        Country currentCountry,
        List<Hobby> hobbies,
        List<Interest> interests,
        string identityUserId
        )
    {
        var userProfile = new UserProfile
        (
            id,
            firstName,
            lastName,
            birthdate,
            gender,
            nativeLanguageId,
            countryOfOrigin,
            currentCountry,
            new List<UserHobby>(),
            new List<UserInterest>(),
            identityUserId
        );

        userProfile.UserHobbies = hobbies.Select(hobby => new UserHobby { Hobby = hobby }).ToList();
        userProfile.UserInterests = interests.Select(interest => new UserInterest { Interest = interest }).ToList();
        userProfile.AddDomainEvent(new ProfileCreatedEvent(userProfile.Id));
        return userProfile;
    }


}
