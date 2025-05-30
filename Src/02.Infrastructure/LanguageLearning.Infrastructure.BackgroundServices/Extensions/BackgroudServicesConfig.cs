using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Infrastructure.BackgroundServices.Extensions;
public static class BackgroudServicesConfig
{
    public static void ConfigureBackgroudServices(this IServiceCollection services)
    {
        services.AddHostedService<JourneyProcessingService>();
    }
}
