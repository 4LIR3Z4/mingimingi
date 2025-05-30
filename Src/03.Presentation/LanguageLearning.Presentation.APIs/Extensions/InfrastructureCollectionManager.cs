using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using LanguageLearning.Infrastructure.AI.Services;
using LanguageLearning.Infrastructure.Caching;
using LanguageLearning.Infrastructure.IdGenerator;
using LanguageLearning.Infrastructure.Security;
using LanguageLearning.Infrastructure.BackgroundServices.Extensions;
namespace LanguageLearning.Presentation.API.ServiceCollectionManager;

public static class InfrastructureCollectionManager
{
    public static void RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
    {


        //External Services
        services.AddScoped<ICacheService, FusionHybridCache>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IReferenceDataCache, ReferenceDataCache>();
        services.AddSingleton<IIdGenerator, SnowflakeIdGenerator>();
        services.AddScoped<ILearningPathGenerator, LearningPathGenerator>();
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.ConfigureBackgroudServices();
        //services.AddScoped<IDomainEventService, DomainEventService>();



    }



}
