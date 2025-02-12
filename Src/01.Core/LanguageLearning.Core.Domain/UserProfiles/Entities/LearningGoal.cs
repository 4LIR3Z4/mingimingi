using LanguageLearning.Core.Domain.UserProfiles.Constants;
using LanguageLearning.Core.Domain.UserProfiles.Enums;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public class LearningGoal : BaseEntity<int>
{
    public SkillType Skill { get; private set; }
    public int PracticePerDayMinutes { get; }
    private LearningGoal() { }
    private LearningGoal(SkillType skill, int practicePerDayMinutes)
    {
        Skill = skill;
        PracticePerDayMinutes = practicePerDayMinutes;
    }
    public static LearningGoal Create(SkillType skill, int practicePerDayMinutes)
    {
        if (practicePerDayMinutes < LearningGoalConstants.MinimumPracticeTime)
            throw new ArgumentException($"minimum PracticeTime is {LearningGoalConstants.MinimumPracticeTime}");
        return new LearningGoal(skill, practicePerDayMinutes);
    }
}
