namespace LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;
public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
