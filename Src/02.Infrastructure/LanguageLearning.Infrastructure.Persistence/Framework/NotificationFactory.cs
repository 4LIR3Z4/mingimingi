using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;
using LanguageLearning.Core.Domain.Framework;
using MediatR;

namespace LanguageLearning.Infrastructure.Persistence.Framework;
public class NotificationFactory : INotificationFactory
{
    public INotification? CreateNotification(DomainEvent domainEvent)
    {
        // Implement your logic to map domain events to notifications
        return domainEvent switch
        {
            
            _ => null,
        };
    }
}