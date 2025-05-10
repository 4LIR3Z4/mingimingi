using LanguageLearning.Core.Domain.LearningJourneys.Enums;

namespace LanguageLearning.Core.Domain.LearningJourneys.Entities;

public sealed class AssessmentItem : BaseEntity<long>
{
    public string Question { get; private set; } = null!;
    public string CorrectAnswer { get; private set; } = null!;
    public string UserAnswer { get; private set; } = null!;
    public bool IsCorrect { get; private set; }
    public SkillType TargetedSkill { get; private set; }
    public ContentDifficulty Difficulty { get; private set; }

    private AssessmentItem() { }

    private AssessmentItem(string question, string correctAnswer, SkillType targetedSkill, ContentDifficulty difficulty)
    {
        Question = question;
        CorrectAnswer = correctAnswer;
        TargetedSkill = targetedSkill;
        Difficulty = difficulty;
        UserAnswer = string.Empty;
        IsCorrect = false;
    }

    public static AssessmentItem Create(string question, string correctAnswer, SkillType targetedSkill, ContentDifficulty difficulty)
    {
        if (string.IsNullOrWhiteSpace(question))
            throw new ArgumentException("Question cannot be empty", nameof(question));
        if (string.IsNullOrWhiteSpace(correctAnswer))
            throw new ArgumentException("Correct answer cannot be empty", nameof(correctAnswer));

        return new AssessmentItem(question, correctAnswer, targetedSkill, difficulty);
    }

    public void SubmitAnswer(string userAnswer)
    {
        UserAnswer = userAnswer;
        // This is a simplified check - in a real app, you might have a more sophisticated matching logic
        IsCorrect = string.Equals(userAnswer.Trim(), CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}
