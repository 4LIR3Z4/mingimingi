namespace LanguageLearning.Core.Domain.Framework.Events;
public interface IDomainEventDispatcher
{
    //void RegisterHandler<TDomainEvent>(IDomainEventHandler<TDomainEvent> handler)
    //    where TDomainEvent : IDomainEvent;
    void RegisterHandler<TDomainEvent>(Func<TDomainEvent, CancellationToken, Task> handler)
        where TDomainEvent : IDomainEvent;
    Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
        where TDomainEvent : IDomainEvent;
}