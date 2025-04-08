using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Infrastructure.Caching;
using LanguageLearning.Infrastructure.IdGenerator;
namespace LanguageLearning.Presentation.API.ServiceCollectionManager;

public static class InfrastructureCollectionManager
{
    public static void RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
    {


        //External Services
        services.AddScoped<ICacheService, FusionHybridCache>();
        services.AddScoped<IReferenceDataCache, ReferenceDataCache>();
        services.AddSingleton<IIdGenerator, SnowflakeIdGenerator>();
        //services.AddScoped<IDomainEventService, DomainEventService>();



    }



}
