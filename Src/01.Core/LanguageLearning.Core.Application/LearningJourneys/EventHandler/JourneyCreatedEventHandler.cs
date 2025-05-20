using LanguageLearning.Core.Application.Common.Abstractions.Messaging;
using LanguageLearning.Core.Domain.Framework.Events;
using LanguageLearning.Core.Domain.LearningJourneys.Events;

namespace LanguageLearning.Core.Application.LearningJourneys.EventHandler;
public sealed class JourneyCreatedEventHandler : IDomainEventHandler<JourneyCreatedEvent>
{
    private readonly IMessageBroker _messageBroker;
    private readonly TimeProvider _timeProvider;
    public JourneyCreatedEventHandler(IMessageBroker messageBroker, TimeProvider timeProvider)
    {
        _messageBroker = messageBroker;
        _timeProvider = timeProvider;
    }

    public async Task Handle(JourneyCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        if (domainEvent is not null)
        {
            JourneyMessage message = new(domainEvent.JourneyId, _timeProvider.GetUtcNow());
            await _messageBroker.PublishMessageAsync(message, "journey", "journey.created", cancellationToken);
        }
    }
}
