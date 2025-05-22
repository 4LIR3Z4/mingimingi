using LanguageLearning.Core.Domain.Framework.Events;

namespace LanguageLearning.Core.Domain.LearningJourneys.Events;
public sealed record LearningPathAddedEvent(long JourneyId) : IDomainEvent;
