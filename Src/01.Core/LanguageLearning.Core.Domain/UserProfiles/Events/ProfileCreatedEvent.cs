using LanguageLearning.Core.Domain.Framework.Events;

namespace LanguageLearning.Core.Domain.UserProfiles.Events;
public record ProfileCreatedEvent(long Id) : IDomainEvent;