using LanguageLearning.Core.Domain.Framework.Events;
using LanguageLearning.Core.Domain.LearningJourneys.Events;

namespace LanguageLearning.Core.Application.LearningJourneys.EventHandler;
public sealed class JourneyCreatedEventHandler : IDomainEventHandler<JourneyCreatedEvent>
{
    public Task Handle(JourneyCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
