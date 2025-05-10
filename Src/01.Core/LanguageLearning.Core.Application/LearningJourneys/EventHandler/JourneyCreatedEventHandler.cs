using LanguageLearning.Core.Application.Common.Abstractions.Messaging;
using LanguageLearning.Core.Domain.Framework.Events;
using LanguageLearning.Core.Domain.LearningJourneys.Events;

namespace LanguageLearning.Core.Application.LearningJourneys.EventHandler;
public sealed class JourneyCreatedEventHandler : IDomainEventHandler<JourneyCreatedEvent>
{
    private readonly IMessageBroker _messageBroker;

    public JourneyCreatedEventHandler(IMessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
    }

    public async Task Handle(JourneyCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        if(domainEvent is not null)
        {
            var message = new
            {
                JourneyId = domainEvent.JourneyId,
                CreatedAt = DateTime.UtcNow
            };
            await _messageBroker.Publish(message, "journey", "journey.created", cancellationToken);
        }
    }
}
