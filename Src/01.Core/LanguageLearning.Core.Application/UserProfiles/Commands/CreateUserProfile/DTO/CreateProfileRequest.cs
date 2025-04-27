using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile.DTO;
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
    public int LearningGoalDailyPracticeMinutes { get; set; }
    public int LearningGoalType { get; set; }
    public List<int> LearningGoalSkillsToImprove { get; set; } = null!;
    public string LearningGoalDescription { get; set; } = string.Empty;

    public int CountryOfOrigin { get; set; }
    public int CurrentCountry { get; set; }
    public List<int> Interests { get; set; } = null!;
}

