namespace LanguageLearning.Core.Application.Common.Abstractions.Messaging.Dto;
public sealed record JourneyMessage(long JourneyId, DateTimeOffset CreatedAt);