using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;
using LanguageLearning.Core.Application.UserProfiles.EventHandler;
using LanguageLearning.Core.Domain.UserProfiles.Events;
using LanguageLearning.Infrastructure.Persistence.DataContext;
using LanguageLearning.Infrastructure.Persistence.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Infrastructure.Persistence.Extensions;
public static class DbContextConfig
{
    public static void ConfigDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IDbContext, DefaultDbContext>(
            opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), sqlServerOptions =>
            {
                sqlServerOptions.CommandTimeout(5);
                sqlServerOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null);
            })
            );
        services.AddSingleton<IDomainEventDispatcher>(sp =>
        {
            var dispatcher = new DomainEventDispatcher();
            var emailService = sp.GetRequiredService<IEmailService>();

            dispatcher.RegisterHandler<ProfileCreatedEvent>(async (domainEvent, cancellationToken) =>
            {
                var handler = new ProfileCreatedEmailHandler(emailService);
                await handler.Handle(domainEvent, cancellationToken);
            });
            return (IDomainEventDispatcher)dispatcher;
        });
    }
}
