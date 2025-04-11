using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Domain.LearningJourney.Entities;
public sealed class LearningPath : BaseEntity<long>
{
    public DateTimeOffset CreatedDate { get; private set; }
    public PathStatus Status { get; private set; }

    private readonly List<LearningSession> _sessions = new();
    public IReadOnlyCollection<LearningSession> Sessions => _sessions.AsReadOnly();
    public bool IsCompleted => Sessions.All(s => s.Status == SessionStatus.Completed);
    public void AddSession(LearningSession session)
    {
        _sessions.Add(session);
    }
    public void UpdateStatus(PathStatus status)
    {
        Status = status;
    }
}
