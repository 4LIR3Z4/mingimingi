using LanguageLearning.Core.Domain.LearningJourney.Enums;

namespace LanguageLearning.Core.Domain.LearningJourney.Entities;
public sealed class LearningPath : BaseEntity<long>
{
    public DateTimeOffset CreatedDate { get; private set; }
    public PathStatus Status { get; private set; }
    public int TotalSessions { get; private set; }
    public int ReadingPerDayInMinutes { get; private set; }
    public int ListeningPerDayInMinutes { get; private set; }
    public int SpeakingPerDayInMinutes { get; private set; }
    public int WritingPerDayInMinutes { get; private set; }
    public int TotalTimeInMinutes => ReadingPerDayInMinutes + ListeningPerDayInMinutes + SpeakingPerDayInMinutes + WritingPerDayInMinutes;
    public int CompletedSessions => Sessions.Count(s => s.Status == SessionStatus.Completed);

    private readonly List<LearningSession> _sessions = new();
    public IReadOnlyCollection<LearningSession> Sessions => _sessions.AsReadOnly();
    public bool IsCompleted => Sessions.All(s => s.Status == SessionStatus.Completed);

    private LearningPath(DateTimeOffset createdDate, PathStatus status, int totalSessions, int readingPerDayInMinutes, int listeningPerDayInMinutes, int speakingPerDayInMinutes, int writingPerDayInMinutes, List<LearningSession> sessions)
    {
        CreatedDate = createdDate;
        Status = status;
        TotalSessions = totalSessions;
        ReadingPerDayInMinutes = readingPerDayInMinutes;
        ListeningPerDayInMinutes = listeningPerDayInMinutes;
        SpeakingPerDayInMinutes = speakingPerDayInMinutes;
        WritingPerDayInMinutes = writingPerDayInMinutes;
        _sessions = sessions;
    }
    public static LearningPath Create(
    DateTimeOffset createdDate,
    PathStatus status,
    int totalSessions,
    int readingPerDayInMinutes,
    int listeningPerDayInMinutes,
    int speakingPerDayInMinutes,
    int writingPerDayInMinutes)
    {
        if (totalSessions <= 0)
        {
            throw new ArgumentException("Total sessions must be greater than zero.", nameof(totalSessions));
        }

        if (readingPerDayInMinutes < 0 || listeningPerDayInMinutes < 0 || speakingPerDayInMinutes < 0 || writingPerDayInMinutes < 0)
        {
            throw new ArgumentException("Daily time values cannot be negative.");
        }

        return new LearningPath(
            createdDate,
            status,
            totalSessions,
            readingPerDayInMinutes,
            listeningPerDayInMinutes,
            speakingPerDayInMinutes,
            writingPerDayInMinutes,
            new()
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
