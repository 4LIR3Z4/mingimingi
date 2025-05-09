using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Domain.LearningJourney.Entities;

public class LearningJourney : BaseAggregateRoot<long>
{
    public long UserId { get; private set; }
    public int LanguageId { get; private set; }
    public LearningTarget LearningTarget { get; private set; }
    public int PracticePerDayInMinutes { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; }
    private readonly List<LanguageProficiency> _proficiencyHistory;
    public IReadOnlyCollection<LanguageProficiency> ProficiencyHistory => _proficiencyHistory.AsReadOnly();

    private readonly List<LearningPath> _learningPaths;
    public IReadOnlyCollection<LearningPath> LearningPaths => _learningPaths.AsReadOnly();
    private LearningJourney()
    {
        _proficiencyHistory = new List<LanguageProficiency>();
        _learningPaths = new List<LearningPath>();
    }

    private LearningJourney(long userId,
        int languageId,
        LearningTarget learningTarget,
        List<LanguageProficiency> proficiencyHistory,
        List<LearningPath> learningPaths)
    {
        UserId = userId;
        LanguageId = languageId;
        LearningTarget = learningTarget;
        _proficiencyHistory = proficiencyHistory;
        _learningPaths = learningPaths;
    }
    public static LearningJourney Create(
        long userId,
        int languageId,
        List<LanguageProficiency> proficiencyHistory,
        List<LearningPath> learningPaths)
    {

        return new LearningJourney(userId, languageId, LearningTarget.General_Training, proficiencyHistory, learningPaths);
    }
    public void AddProficiency(LanguageProficiency proficiency)
    {
        _proficiencyHistory.Add(proficiency);
    }
}

