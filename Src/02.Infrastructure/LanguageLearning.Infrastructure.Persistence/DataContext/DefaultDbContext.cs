using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Domain.Framework;
using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LanguageLearning.Infrastructure.Persistence.DataContext;


public sealed class DefaultDbContext(
    DbContextOptions options,
    IPublisher mediator
    //,IDomainEventService domainEventService 
    ) :
    DbContext(options), IDbContext
{
    //private readonly IDomainEventService _domainEventService = domainEventService;
    private readonly IPublisher _mediator = mediator;

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Hobby> Hobbies { get ; set ; }
    public DbSet<Interest> Interests { get ; set ; }
    public DbSet<Language> Languages { get ; set ; }
    public DbSet<Country> Countries { get ; set ; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents();

        return result;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfigurationsFromAssembly(typeof(DefaultDbContext).Assembly);

        base.OnModelCreating(builder);
    }
    private async Task DispatchEvents()
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
            await _mediator.Publish(domainEvent);
        }

        //await _domainEventService.Publish(domainEventEntity);

    }
}
