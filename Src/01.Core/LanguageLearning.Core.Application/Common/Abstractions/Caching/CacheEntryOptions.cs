namespace LanguageLearning.Core.Application.Common.Abstractions.Caching;
public record CacheEntryOptions(
    TimeSpan? Duration,
    bool? IsFailSafeEnabled = false,
    TimeSpan? FailSafeMaxDuration = null,
    TimeSpan? JitterMaxDuration = null
);
