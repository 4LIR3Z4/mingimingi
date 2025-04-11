using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Domain.LearningJourney.Entities;

public sealed class LearningContent : BaseEntity<long>
{
    public SkillType SkillType { get; private set; }
    public string Title { get; private set; } = null!;
    public string ContentData { get; private set; } = null!;
    public string ContentMetadata { get; private set; } = null!;
    public int TimeNeededToComplete { get; private set; }
    public DateTimeOffset? StartLearningTime { get; private set; }
    public DateTimeOffset? FinishedLearningTime { get; private set; }
    public long CompletedDurationMinutes
    {
        get
        {
            if (StartLearningTime == null || FinishedLearningTime == null)
            {
                return 0;
            }
            return (long)Math.Abs((FinishedLearningTime.Value - StartLearningTime.Value).TotalMinutes);
        }
    }
    public bool HasFinished => FinishedLearningTime.HasValue;
    public ContentType ContentType { get; private set; }
    public ContentDifficulty Difficulty { get; private set; }
    private LearningContent() { }

    private LearningContent(SkillType skillType, string title, string contentData, string contentMetadata, ContentDifficulty difficulty)
    {
        SkillType = skillType;
        Title = title;
        ContentData = contentData;
        ContentMetadata = contentMetadata;
        Difficulty = difficulty;
    }

    public static LearningContent Create(SkillType skillType, string title, string contentData, string contentMetadata, ContentDifficulty difficulty)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));
        if (string.IsNullOrWhiteSpace(contentData))
            throw new ArgumentException("Content data cannot be empty", nameof(contentData));

        return new LearningContent(skillType, title, contentData, contentMetadata, difficulty);
    }
}
