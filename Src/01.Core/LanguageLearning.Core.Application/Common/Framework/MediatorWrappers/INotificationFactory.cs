namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;
public interface INotificationFactory
{
    INotification? CreateNotification(DomainEvent domainEvent);
}
