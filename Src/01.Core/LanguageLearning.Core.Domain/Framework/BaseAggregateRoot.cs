
namespace LanguageLearning.Core.Domain.Framework;
public abstract class BaseAggregateRoot<TId> : BaseEntity<TId>, IHasDomainEvent
{
    protected BaseAggregateRoot() : base()
    {
    }
    protected BaseAggregateRoot(TId Id) : base(Id)
    {
    }
    private List<DomainEvent> _DomainEvents { get; } = new();

    public IReadOnlyList<DomainEvent> DomainEvents => _DomainEvents.AsReadOnly();

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _DomainEvents.Add(domainEvent);
    }

    public void ClearEvents() => _DomainEvents.Clear();
}
