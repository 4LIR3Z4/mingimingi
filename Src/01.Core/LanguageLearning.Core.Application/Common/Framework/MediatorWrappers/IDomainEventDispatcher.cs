using LanguageLearning.Core.Domain.Framework.Events;

namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;
public interface IDomainEventDispatcher
{
    void RegisterHandler<TDomainEvent>(IDomainEventHandler<TDomainEvent> handler)
        where TDomainEvent : IDomainEvent;

    Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
        where TDomainEvent : IDomainEvent;
}