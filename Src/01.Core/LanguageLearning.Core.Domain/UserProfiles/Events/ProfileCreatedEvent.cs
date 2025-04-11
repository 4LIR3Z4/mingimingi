using LanguageLearning.Core.Domain.Framework.Events;

namespace LanguageLearning.Core.Domain.UserProfiles.Events;
public sealed record ProfileCreatedEvent(long Id) : IDomainEvent;