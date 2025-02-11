namespace LanguageLearning.Core.Application.Common.Abstractions;
public interface ICacheService
{
    Task<T> GetOrSetAsync<T>(
        string key,
        Func<CancellationToken, Task<T>> factory,
        TimeSpan? duration = null,
        CancellationToken ct = default
    );

    Task RemoveAsync(string key, CancellationToken ct = default);
}
