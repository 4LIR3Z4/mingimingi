using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Domain.LearningJourney.Entities;

public class LearningJourney : BaseAggregateRoot<long>
{
    public long UserId { get; private set; }
    public int LanguageId { get; private set; }

    private readonly List<LearningGoal> _goals;
    public IReadOnlyCollection<LearningGoal> Goals => _goals.AsReadOnly();
    private readonly List<LanguageProficiency> _proficiencyHistory;
    public IReadOnlyCollection<LanguageProficiency> ProficiencyHistory => _proficiencyHistory.AsReadOnly();

    private LearningJourney()
    {
        _goals = new List<LearningGoal>();
        _proficiencyHistory = new List<LanguageProficiency>();
    }

    public LearningJourney(long userId, int languageId, List<LearningGoal> goals, List<LanguageProficiency> proficiencyHistory)
    {
        UserId = userId;
        LanguageId = languageId;
        _goals = goals;
        _proficiencyHistory = proficiencyHistory;
    }
    public static LearningJourney Create(long userId, int languageId, List<LearningGoal> goals, List<LanguageProficiency> proficiencyHistory)
    {
        if (goals == null)
        {
            throw new ArgumentNullException(nameof(goals), "Goals list cannot be null.");
        }
        var skillTypes = Enum.GetValues(typeof(SkillType)).Cast<SkillType>().ToList();

        if (goals.Count != skillTypes.Count)
        {
            throw new ArgumentException(
                $"LearningJourney must have exactly {skillTypes.Count} goals (one per SkillType).");
        }

        foreach (var skillType in skillTypes)
        {
            int count = goals.Count(g => g.Skill == skillType);
            if (count != 1)
            {
                throw new ArgumentException(
                    $"LearningJourney must have exactly one LearningGoal for SkillType {skillType}.");
            }
        }
        return new LearningJourney(userId, languageId, goals, proficiencyHistory);
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

