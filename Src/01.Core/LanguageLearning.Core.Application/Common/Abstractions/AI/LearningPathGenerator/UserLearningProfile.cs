namespace LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
public sealed class UserLearningProfile
{
    public int Age { get; set; }
    public string Gender { get; set; } = null!;
    public string CountryOfOrigin { get; set; } = null!;
    public string CurrentCountry { get; set; } = null!;
    public string TargetLanguage { get; set; } = null!;

    public List<string> Hobbies { get; set; } = null!;
    public List<string> Interests { get; set; } = null!;
    public string LearningTarget { get; set; } = null!;
    public int PracticeTimePerDayInMinutes { get; set; }

    /// <summary>
    /// Proficiency Level per skill
    /// </summary>
    /// <example>
    /// reading,beginner
    /// writing,intermediate
    /// </example>
    public Dictionary<string, string> LanguageProficiencies { get; set; } = null!;


}
