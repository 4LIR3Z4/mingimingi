using LanguageLearning.Core.Domain.LearningJourneys.Enums;

namespace LanguageLearning.Core.Domain.LearningJourneys.Entities;
public sealed class LearningPath : BaseEntity<long>
{
    public DateTimeOffset CreatedDate { get; private set; }
    public PathStatus Status { get; private set; }
    public int TotalSessions { get; private set; }

    public int CompletedSessions => Sessions.Count(s => s.Status == SessionStatus.Completed);

    private readonly List<LearningSession> _sessions = new();
    public IReadOnlyCollection<LearningSession> Sessions => _sessions.AsReadOnly();
    public bool IsCompleted => Sessions.All(s => s.Status == SessionStatus.Completed);

    private LearningPath(DateTimeOffset createdDate, PathStatus status, int totalSessions)
    {
        CreatedDate = createdDate;
        Status = status;
        TotalSessions = totalSessions;
    }
    public static LearningPath Create(
    DateTimeOffset createdDate,
    int totalSessions)
    {
        if (totalSessions <= 0)
        {
            throw new ArgumentException("Total sessions must be greater than zero.", nameof(totalSessions));
        }

        return new LearningPath(
            createdDate,
            PathStatus.Active,
            totalSessions
        );
    }

    public void AddSession(LearningSession session)
    {
        _sessions.Add(session);
    }
    public void UpdateStatus(PathStatus status)
    {
        Status = status;
    }
}
