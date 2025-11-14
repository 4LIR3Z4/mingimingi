using LanguageLearning.Core.Domain.LearningJourneys.Enums;

namespace LanguageLearning.Core.Application.Common.Abstractions.AI.LLM.LearningPathGenerator;

public sealed record ContentAssessment(
    string Question,
    string CorrectAnswer,
    bool IsCorrect,
    SkillType TargetedSkill,
    ContentDifficulty Difficulty
);

public sealed record SessionAssessment(
    List<ContentAssessment> Assessments
);
