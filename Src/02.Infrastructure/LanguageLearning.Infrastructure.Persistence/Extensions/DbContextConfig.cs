using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Infrastructure.Persistence.DataContext;
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
    }
}
