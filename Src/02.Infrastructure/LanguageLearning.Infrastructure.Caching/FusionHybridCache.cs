using LanguageLearning.Core.Application.Common.Abstractions;
using ZiggyCreatures.Caching.Fusion;

namespace LanguageLearning.Infrastructure.Caching;
public class FusionHybridCache : ICacheService
{
    private readonly IFusionCache _cache;

    public FusionHybridCache(IFusionCache cache)
    {
        _cache = cache;
    }

    public async Task<T> GetOrSetAsync<T>(string key, Func<CancellationToken, Task<T>> factory, TimeSpan? duration = null, CancellationToken ct = default)
    {
        var options = new FusionCacheEntryOptions
        {
            Duration = duration ?? TimeSpan.FromMinutes(5),
            IsFailSafeEnabled = true, // Return stale data on errors
            FailSafeMaxDuration = TimeSpan.FromHours(1),
            JitterMaxDuration = TimeSpan.FromSeconds(1) // Prevent stampedes
        };

        return await _cache.GetOrSetAsync<T>(
            key,
            async (ctx, _) => await factory(ct),
            options,
            ct
        );
    }

    public async Task RemoveAsync(string key, CancellationToken ct = default)
    {
        await _cache.RemoveAsync(key, token: ct);
    }
}
