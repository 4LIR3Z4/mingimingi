using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.Prompts.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using ZiggyCreatures.Caching.Fusion;

namespace LanguageLearning.Infrastructure.Caching;
public class ReferenceDataCache : IReferenceDataCache
{
    private readonly IDbContext _dbContext;
    private readonly IFusionCache _cache;

    public ReferenceDataCache(IDbContext dbContext, IFusionCache cache)
    {
        this._dbContext = dbContext;
        this._cache = cache;
    }

    public async Task<List<Hobby>> GetHobbiesAsync(CancellationToken cancellationToken)
    {
        var options = new FusionCacheEntryOptions
        {
            Duration = TimeSpan.FromMinutes(5),
            IsFailSafeEnabled = true, // Return stale data on errors
            FailSafeMaxDuration = TimeSpan.FromHours(1),
            JitterMaxDuration = TimeSpan.FromSeconds(1) // Prevent stampedes
        };
        return await _cache.GetOrSetAsync<List<Hobby>>("hobbies",
            async (ctx, c) =>
            {
                return await _dbContext.Hobbies.AsNoTracking().ToListAsync(c);
            }
        , options, cancellationToken);
    }

    public async Task<List<Interest>> GetInterestsAsync(CancellationToken cancellationToken)
    {
        var options = new FusionCacheEntryOptions
        {
            Duration = TimeSpan.FromMinutes(5),
            IsFailSafeEnabled = true, // Return stale data on errors
            FailSafeMaxDuration = TimeSpan.FromHours(1),
            JitterMaxDuration = TimeSpan.FromSeconds(1) // Prevent stampedes
        };
        return await _cache.GetOrSetAsync<List<Interest>>("Interests",
            async (ctx, c) =>
            {
                return await _dbContext.Interests.AsNoTracking().ToListAsync(c);
            }
        , options, cancellationToken);
    }

    public async Task<List<Language>> GetLanguagesAsync(CancellationToken cancellationToken)
    {
        var options = new FusionCacheEntryOptions
        {
            Duration = TimeSpan.FromMinutes(5),
            IsFailSafeEnabled = true, // Return stale data on errors
            FailSafeMaxDuration = TimeSpan.FromHours(1),
            JitterMaxDuration = TimeSpan.FromSeconds(1) // Prevent stampedes
        };
        return await _cache.GetOrSetAsync<List<Language>>("Languages",
            async (ctx, c) =>
            {
                return await _dbContext.Languages.AsNoTracking().ToListAsync(c);
            }
        , options, cancellationToken);
    }
    public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
    {
        var options = new FusionCacheEntryOptions
        {
            Duration = TimeSpan.FromMinutes(5),
            IsFailSafeEnabled = true, // Return stale data on errors
            FailSafeMaxDuration = TimeSpan.FromHours(1),
            JitterMaxDuration = TimeSpan.FromSeconds(1) // Prevent stampedes
        };
        return await _cache.GetOrSetAsync<List<Country>>("Languages",
            async (ctx, c) =>
            {
                return await _dbContext.Countries.AsNoTracking().ToListAsync(c);
            }
        , options, cancellationToken);
    }

    public async Task<List<Prompt>> GetPromptsAsync(CancellationToken cancellationToken)
    {
        var options = new FusionCacheEntryOptions
        {
            Duration = TimeSpan.FromHours(1),
            IsFailSafeEnabled = true, // Return stale data on errors
            FailSafeMaxDuration = TimeSpan.FromHours(1),
            JitterMaxDuration = TimeSpan.FromSeconds(1) // Prevent stampedes
        };
        return await _cache.GetOrSetAsync<List<Prompt>>("Prompts",
            async (ctx, c) =>
            {
                return await _dbContext.Prompts.AsNoTracking().ToListAsync(c);
            }
        , options, cancellationToken);
    }
}
