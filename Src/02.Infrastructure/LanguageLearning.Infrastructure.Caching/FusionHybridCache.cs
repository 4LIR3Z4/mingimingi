using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using ZiggyCreatures.Caching.Fusion;

namespace LanguageLearning.Infrastructure.Caching;
public class FusionHybridCache : ICacheService
{
    private readonly IFusionCache _cache;

    public FusionHybridCache(IFusionCache cache)
    {
        _cache = cache;
    }

    public async Task<T> GetOrSetAsync<T>(string key, Func<CancellationToken, Task<T>> factory, CacheEntryOptions? options , CancellationToken ct = default)
    {
        return await _cache.GetOrSetAsync<T>(
            key,
            async (ctx, _) => await factory(ct),
            options:new FusionCacheEntryOptions()
            {
                Duration = options?.Duration ?? TimeSpan.FromMinutes(5),
                IsFailSafeEnabled = options?.IsFailSafeEnabled ?? true,
                FailSafeMaxDuration = options?.FailSafeMaxDuration ?? TimeSpan.FromHours(1),
                JitterMaxDuration = options?.JitterMaxDuration ?? TimeSpan.FromSeconds(1)
            },
            ct
        );
    }
    public async Task RemoveAsync(string key, CancellationToken ct = default)
    {
        await _cache.RemoveAsync(key, token: ct);
    }
}
