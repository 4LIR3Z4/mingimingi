namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging;
public record JourneyMessage(long JourneyId, DateTimeOffset CreatedAt);