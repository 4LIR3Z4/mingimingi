using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Domain.LearningJourney.Entities;

public class LearningSession : BaseEntity<long>
{
    public DateTimeOffset CreatedDate { get; private set; }
    public DateTimeOffset FinishedDate { get; private set; }

    public SessionStatus Status { get; private set; }

    private readonly List<LearningContent> _contents;
    public IReadOnlyCollection<LearningContent> Contents => _contents.AsReadOnly();

    private readonly List<AssessmentItem> _assessments;
    public IReadOnlyCollection<AssessmentItem> Assessments => _assessments.AsReadOnly();

    private LearningSession()
    {
        _contents = new List<LearningContent>();
        _assessments = new List<AssessmentItem>();
    }

    public static LearningSession Start(DateTimeOffset startTime)
    {
        return new LearningSession();
    }
    public static LearningSession Create(DateTimeOffset startTime)
    {
        return new LearningSession();
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
