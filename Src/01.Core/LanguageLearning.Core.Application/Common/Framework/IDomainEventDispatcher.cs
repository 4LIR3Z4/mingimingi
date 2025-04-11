using LanguageLearning.Core.Domain.Framework.Events;

namespace LanguageLearning.Core.Application.Common.Framework;
public interface IDomainEventDispatcher
{
    //void RegisterHandler<TDomainEvent>(IDomainEventHandler<TDomainEvent> handler)
    //    where TDomainEvent : IDomainEvent;
    void RegisterHandler<TDomainEvent>(Func<TDomainEvent, CancellationToken, Task> handler)
        where TDomainEvent : IDomainEvent;
    Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
        where TDomainEvent : IDomainEvent;
}
public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly Dictionary<Type, List<Func<IDomainEvent, CancellationToken, Task>>> _handlers
       = new();

    public void RegisterHandler<TDomainEvent>(Func<TDomainEvent, CancellationToken, Task> handler)
        where TDomainEvent : IDomainEvent
    {
        var eventType = typeof(TDomainEvent);

        if (!_handlers.ContainsKey(eventType))
        {
            _handlers[eventType] = new List<Func<IDomainEvent, CancellationToken, Task>>();
        }

        _handlers[eventType].Add((domainEvent, cancellationToken) =>
            handler((TDomainEvent)domainEvent, cancellationToken));
    }

    public async Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
        where TDomainEvent : IDomainEvent
    {
        var eventType = typeof(TDomainEvent);

        if (_handlers.TryGetValue(eventType, out var handlers))
        {
            var tasks = handlers.Select(handler => handler(domainEvent, cancellationToken));
            await Task.WhenAll(tasks);
        }
    }
}