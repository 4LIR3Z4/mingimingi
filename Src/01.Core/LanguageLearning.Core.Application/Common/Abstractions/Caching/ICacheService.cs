namespace LanguageLearning.Core.Application.Common.Abstractions.Caching;
public interface ICacheService
{
    Task<T> GetOrSetAsync<T>(
        string key,
        Func<CancellationToken, Task<T>> factory,
        CacheEntryOptions? options,
        CancellationToken ct = default
    );

    Task RemoveAsync(string key, CancellationToken ct = default);
}
