using LanguageLearning.Core.Domain.LearningJourneys.Enums;

namespace LanguageLearning.Core.Domain.LearningJourneys.Entities;

public sealed class LearningSession : BaseEntity<long>
{
    public DateTimeOffset CreatedDate { get; private set; }
    public DateTimeOffset FinishedDate { get; private set; }

    public SessionStatus Status { get; private set; }

    private readonly List<LearningContent> _contents;
    public IReadOnlyCollection<LearningContent> Contents => _contents.AsReadOnly();

    private readonly List<AssessmentItem> _assessments;
    public IReadOnlyCollection<AssessmentItem> Assessments => _assessments.AsReadOnly();

    private LearningSession(SessionStatus status, DateTimeOffset createdDate)
    {
        _contents = new List<LearningContent>();
        _assessments = new List<AssessmentItem>();
        CreatedDate = createdDate;
        Status = status;
    }
    public static LearningSession Create(DateTimeOffset createdDate)
    {
        return new LearningSession(SessionStatus.Planned, createdDate);
    }
    public void AddContent(LearningContent content)
    {
        _contents.Add(content);
    }

    public void AddAssessment(AssessmentItem assessment)
    {
        _assessments.Add(assessment);
    }

    public void CompleteSession(DateTimeOffset finishedDate)
    {
        FinishedDate = finishedDate;
    }
}
