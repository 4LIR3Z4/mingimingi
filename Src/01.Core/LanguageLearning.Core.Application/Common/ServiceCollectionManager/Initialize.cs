using LanguageLearning.Core.Application.Agreements.Commands;
using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;
namespace LanguageLearning.Core.Application.Common.ServiceCollectionManager;
public static class Initialize
{
    public static void InitApplication(this IServiceCollection services)
    {

        services.AddValidatorsFromAssemblyContaining<CreateAgreementCommandValidator>(includeInternalTypes: true);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(Initialize).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
        services.AddScoped<IMediatorService, MediatorService>();

    }


}
