using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Framework;
using LanguageLearning.Core.Domain.Framework.Events;
using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearning.Infrastructure.Persistence.DataContext;


public sealed class DefaultDbContext(
    DbContextOptions options,
    IDomainEventDispatcher domainEventDispatcher
    //,IDomainEventService domainEventService 
    ) :
    DbContext(options), IDbContext
{
    //private readonly IDomainEventService _domainEventService = domainEventService;
    private readonly IDomainEventDispatcher _domainEventDispatcher = domainEventDispatcher;

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Country> Countries { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(cancellationToken);

        return result;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfigurationsFromAssembly(typeof(DefaultDbContext).Assembly);

        base.OnModelCreating(builder);
    }
    private async Task DispatchEvents(CancellationToken cancellationToken)
    {
        var domainEvents = ChangeTracker
            .Entries<IHasDomainEvent>()
            .Select(x => x.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.DomainEvents;
                entity.ClearEvents();
                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _domainEventDispatcher.Publish(domainEvent, cancellationToken);
        }

        //await _domainEventService.Publish(domainEventEntity);

    }
}
