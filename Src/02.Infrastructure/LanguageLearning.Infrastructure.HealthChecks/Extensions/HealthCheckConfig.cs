using LanguageLearning.Infrastructure.Persistence.DataContext;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Infrastructure.HealthChecks.Extensions;
public static class HealthCheckConfig
{
    public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks().AddDbContextCheck<LanguageLearningContext>();
    }
    public static void MapHealthChecks(this WebApplication app, string path = "/health")
    {
        app.MapHealthChecks(path, new()
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}
