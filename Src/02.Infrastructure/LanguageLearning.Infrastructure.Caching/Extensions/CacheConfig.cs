using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using ZiggyCreatures.Caching.Fusion;
using ZiggyCreatures.Caching.Fusion.Serialization.SystemTextJson;

namespace LanguageLearning.Infrastructure.Caching.Extensions;
public static class CacheConfig
{
    public static void ConfigureCaching(this IServiceCollection services)
    {
        services.AddFusionCache()
    .WithDefaultEntryOptions(new FusionCacheEntryOptions
    {
        Duration = TimeSpan.FromMinutes(5),
        //IsFailSafeEnabled = true,
        FailSafeMaxDuration = TimeSpan.FromHours(2),
        JitterMaxDuration = TimeSpan.FromSeconds(1)
    })
    .WithSerializer(new FusionCacheSystemTextJsonSerializer())
    .WithDistributedCache(new RedisCache(new RedisCacheOptions { Configuration = "redis://172.17.0.5" }));
    }
}
