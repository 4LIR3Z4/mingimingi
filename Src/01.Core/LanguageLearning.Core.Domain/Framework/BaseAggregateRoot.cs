
using LanguageLearning.Core.Domain.Framework.Events;

namespace LanguageLearning.Core.Domain.Framework;
public abstract class BaseAggregateRoot<TId> : BaseEntity<TId>, IHasDomainEvent
{
    protected BaseAggregateRoot() : base()
    {
    }
    protected BaseAggregateRoot(TId Id) : base(Id)
    {
    }
    private List<IDomainEvent> _DomainEvents { get; } = new();

    public IReadOnlyList<IDomainEvent> DomainEvents => _DomainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _DomainEvents.Add(domainEvent);
    }

    public void ClearEvents() => _DomainEvents.Clear();
}
