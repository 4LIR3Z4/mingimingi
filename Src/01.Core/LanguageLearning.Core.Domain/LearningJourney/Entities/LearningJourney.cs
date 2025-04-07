using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Domain.LearningJourney.Entities;

public class LearningJourney : BaseAggregateRoot<long>
{
    public long UserId { get; private set; }
    public int LanguageId { get; private set; }
    public LearningTarget LearningTarget { get; private set; }
    public DateTimeOffset CreatedDate { get; }
    private readonly List<LearningGoal> _goals;
    public IReadOnlyCollection<LearningGoal> Goals => _goals.AsReadOnly();
    private readonly List<LanguageProficiency> _proficiencyHistory;
    public IReadOnlyCollection<LanguageProficiency> ProficiencyHistory => _proficiencyHistory.AsReadOnly();

    private readonly List<LearningPath> _learningPaths;
    public IReadOnlyCollection<LearningPath> LearningPaths => _learningPaths.AsReadOnly();
    private LearningJourney()
    {
        _goals = new List<LearningGoal>();
        _proficiencyHistory = new List<LanguageProficiency>();
        _learningPaths = new List<LearningPath>();
    }

    private LearningJourney(long userId,
        int languageId,
        LearningTarget learningTarget,
        List<LearningGoal> goals,
        List<LanguageProficiency> proficiencyHistory,
        List<LearningPath> learningPaths)
    {
        UserId = userId;
        LanguageId = languageId;
        LearningTarget = learningTarget;
        _goals = goals;
        _proficiencyHistory = proficiencyHistory;
        _learningPaths = learningPaths;
    }
    public static LearningJourney Create(
        long userId,
        int languageId,
        List<LearningGoal> goals,
        List<LanguageProficiency> proficiencyHistory,
        List<LearningPath> learningPaths)
    {
        ArgumentNullException.ThrowIfNull(goals, nameof(goals));
        var skillTypes = Enum.GetValues(typeof(SkillType)).Cast<SkillType>().ToList();

        ArgumentOutOfRangeException.ThrowIfNotEqual(goals.Count, skillTypes.Count, nameof(goals.Count));

        foreach (var skillType in skillTypes)
        {
            int count = goals.Count(g => g.Skill == skillType);
            if (count != 1)
            {
                throw new ArgumentException(
                    $"LearningJourney must have exactly one LearningGoal for SkillType {skillType}.");
            }
        }
        return new LearningJourney(userId, languageId, LearningTarget.General_Training, goals, proficiencyHistory, learningPaths);
    }
    public void AddProficiency(LanguageProficiency proficiency)
    {
        _proficiencyHistory.Add(proficiency);
    }
    public void UpdateGoal(LearningGoal updatedGoal)
    {
        var index = _goals.FindIndex(g => g.Skill == updatedGoal.Skill);
        if (index < 0)
        {
            throw new InvalidOperationException($"There is no goal for skill: {updatedGoal.Skill} to update.");
        }
        _goals[index] = updatedGoal;
    }
}

