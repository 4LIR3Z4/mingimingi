using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Infrastructure.Caching;
namespace LanguageLearning.Presentation.API.ServiceCollectionManager;

public static class InfrastructureCollectionManager
{
    public static void RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
    {


        //External Services
        services.AddScoped<ICacheService, FusionHybridCache>();


        //services.AddScoped<IDomainEventService, DomainEventService>();



    }



}
