namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;
public sealed class DomainEventNotification<TDomainEvent> : 
    INotification where TDomainEvent : DomainEvent
{
    public TDomainEvent DomainEvent { get; }
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }
}
