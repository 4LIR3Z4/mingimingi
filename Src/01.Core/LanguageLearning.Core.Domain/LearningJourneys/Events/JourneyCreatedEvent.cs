using LanguageLearning.Core.Domain.Framework.Events;

namespace LanguageLearning.Core.Domain.LearningJourneys.Events;
public sealed record JourneyCreatedEvent(long JourneyId) : IDomainEvent;