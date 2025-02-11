using MediatR;

namespace LanguageLearning.Core.Domain.Framework;
public interface IHasDomainEvent
{
    public IReadOnlyList<DomainEvent> DomainEvents { get; }
    public void ClearEvents();
}

public abstract class DomainEvent : INotification
{
    protected DomainEvent()
    {
        DateOccurred = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset DateOccurred { get; } = DateTime.UtcNow;

    //public bool IsPublished { get; set; }
}
