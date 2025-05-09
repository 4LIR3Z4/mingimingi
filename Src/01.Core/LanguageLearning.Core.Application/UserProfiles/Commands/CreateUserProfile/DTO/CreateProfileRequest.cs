namespace LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile.DTO;
public sealed class CreateProfileRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int Age { get; set; }
    public int Gender { get; set; }
    public int NativeLanguage { get; set; }
    public List<int> Hobbies { get; set; } = null!;
    public int CountryOfOrigin { get; set; }
    public int CurrentCountry { get; set; }
    public List<int> Interests { get; set; } = null!;
}

