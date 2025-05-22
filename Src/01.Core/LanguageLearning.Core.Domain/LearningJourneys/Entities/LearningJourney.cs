using LanguageLearning.Core.Domain.LearningJourneys.Enums;
using LanguageLearning.Core.Domain.LearningJourneys.Events;

namespace LanguageLearning.Core.Domain.LearningJourneys.Entities;

public class LearningJourney : BaseAggregateRoot<long>
{
    public long UserId { get; private set; }
    public int LanguageId { get; private set; }
    public LearningTarget LearningTarget { get; private set; }
    public int PracticePerDayInMinutes { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; }
    private readonly List<LanguageProficiency> _proficiencyHistory;
    public IReadOnlyCollection<LanguageProficiency> ProficiencyHistory => _proficiencyHistory.AsReadOnly();

    private readonly List<LearningPath> _learningPaths = new();
    public IReadOnlyCollection<LearningPath> LearningPaths => _learningPaths.AsReadOnly();
    private LearningJourney()
    {
    }

    private LearningJourney(long id, long userId,
        int languageId,
        LearningTarget learningTarget,
        List<LanguageProficiency> proficiencyHistory) : base(id)
    {
        UserId = userId;
        LanguageId = languageId;
        LearningTarget = learningTarget;
        _proficiencyHistory = proficiencyHistory;
    }
    public static LearningJourney Create(
        long id,
        long userId,
        int languageId,
    List<LanguageProficiency> proficiencyHistory)
    {
        var journey = new LearningJourney(id, userId, languageId, LearningTarget.General_Training, proficiencyHistory);
        journey.AddDomainEvent(new JourneyCreatedEvent(journey.Id));
        return journey;
    }
    public void AddProficiency(LanguageProficiency proficiency)
    {
        _proficiencyHistory.Add(proficiency);
    }
    public void AddLearningPath(LearningPath learningPath)
    {
        _learningPaths.Add(learningPath);
        this.AddDomainEvent(new LearningPathAddedEvent(this.Id));
    }
}

