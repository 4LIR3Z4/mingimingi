namespace LanguageLearning.Core.Domain.Framework.Events;
public interface IHasDomainEvent
{
    public IReadOnlyList<IDomainEvent> DomainEvents { get; }
    public void ClearEvents();
}
