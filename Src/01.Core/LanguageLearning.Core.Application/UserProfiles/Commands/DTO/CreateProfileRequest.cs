using LanguageLearning.Core.Domain.UserProfiles.Enums;

namespace LanguageLearning.Core.Application.UserProfiles.Commands.DTO;
public sealed class CreateProfileRequest
{
    public long Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int Age { get; set; }
    public int Gender { get; set; }
    public int NativeLanguage { get; set; }
    public List<int> Hobbies { get; set; } = null!;
    public int LearningLanguage { get; set; }
    public ProficiencyLevel LearningLanguageProficiencyLevel { get; set; }
    public int CountryOfOrigin { get; set; }
    public int CurrentCountry { get; set; }
    public List<int> Interests { get; set; } = null!;
}

