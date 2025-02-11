using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;
using LanguageLearning.Core.Domain.Framework;
using MediatR;

namespace LanguageLearning.Infrastructure.Persistence.Framework;
/// <summary>
/// this class uses reflection to create instances of notification, so need for adding reference to mediatr inotification interface in the domain project
/// </summary>
/// <param name="mediator"></param>
/// <param name="notificationFactory"></param>
public sealed class DomainEventService(IPublisher mediator, INotificationFactory notificationFactory) 
    : IDomainEventService
{
    private readonly IPublisher _mediator = mediator;
    private readonly INotificationFactory _notificationFactory = notificationFactory;

    public async Task Publish(DomainEvent domainEvent)
    {
        INotification? notificationHandler = GetNotificationCorrespondingToDomainEvent(domainEvent);
        //INotification? notificationHandler = _notificationFactory.CreateNotification(domainEvent);
        if (notificationHandler is not null)
        {
            await _mediator.Publish(notificationHandler);
        }
    }

    private static INotification? GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent) => Activator.CreateInstance(
            typeof(DomainEventNotification<>).
            MakeGenericType(domainEvent.GetType()), domainEvent) as INotification;
}