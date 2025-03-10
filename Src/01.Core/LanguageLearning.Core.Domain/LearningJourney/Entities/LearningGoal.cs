﻿using LanguageLearning.Core.Domain.LearningJourney.Constants;
using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Domain.LearningJourney.Entities;
public class LearningGoal : BaseEntity<int>
{
    public SkillType Skill { get; private set; }
    public LearningGoalType LearningGoalType { get; private set; }
    public int PracticePerDayMinutes { get; private set; }
    public string Description { get; private set; } = string.Empty;
    private LearningGoal() { }
    private LearningGoal(SkillType skill, LearningGoalType learningGoalType, int practicePerDayMinutes, string description)
    {
        Skill = skill;
        PracticePerDayMinutes = practicePerDayMinutes;
        Description = description;
        LearningGoalType = learningGoalType;
    }
    public static LearningGoal Create(
        SkillType skill,
        LearningGoalType learningGoalType,
        int practicePerDayMinutes,
        string description)
    {
        if (practicePerDayMinutes < LearningGoalConstants.MinimumPracticeTime)
            throw new ArgumentException($"minimum PracticeTime is {LearningGoalConstants.MinimumPracticeTime}");
        return new LearningGoal(skill, learningGoalType, practicePerDayMinutes, description);
    }
}
