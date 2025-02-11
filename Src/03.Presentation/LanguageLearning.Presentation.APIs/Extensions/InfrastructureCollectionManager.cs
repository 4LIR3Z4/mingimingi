using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Abstractions.ExternalServices.CBI;
using LanguageLearning.Core.Application.Common.Abstractions.ExternalServices.NezamVazife;
using LanguageLearning.Core.Application.Common.Abstractions.ExternalServices.SabteAhval;
using LanguageLearning.Core.Application.Common.Abstractions.ExternalServices.Shahkar;
using LanguageLearning.Core.Application.Common.Abstractions.ExternalServices.Tosan;
using LanguageLearning.Infrastructure.Caching;
using LanguageLearning.Infrastructure.Services;
using LanguageLearning.Infrastructure.Services.Common;
using LanguageLearning.Infrastructure.Services.NezamVazife;
using LanguageLearning.Infrastructure.Services.SabteAhval;
using LanguageLearning.Infrastructure.Services.Shahkar;
using LanguageLearning.Infrastructure.Services.Tosan.Report;
using LanguageLearning.Infrastructure.Services.Tosan.Yaghout;
namespace LanguageLearning.Presentation.API.ServiceCollectionManager;

public static class InfrastructureCollectionManager
{
    public static void RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
    {


        //External Services
        services.AddScoped<ICBIService, CBIService>();
        services.AddScoped<IShahkarService, ShahkarService>();
        services.AddScoped<ISabteAhavlService, SabteAhavlService>();
        services.AddScoped<ITosanReportService, TosanReportService>();
        services.AddScoped<ITosanYaghoutService, TosanYaghoutService>();
        services.AddScoped<INezamVazifeService, NezamVazifeService>();
        //services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<ICacheService, FusionHybridCache>();


        //services.AddScoped<IDomainEventService, DomainEventService>();



    }



}
