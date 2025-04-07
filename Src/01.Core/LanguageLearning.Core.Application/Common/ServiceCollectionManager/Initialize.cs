using LanguageLearning.Core.Application.Common.Behaviors;
using LanguageLearning.Core.Application.UserProfiles.Commands;
using LanguageLearning.Core.Application.UserProfiles.Commands.DTO;
using Microsoft.Extensions.DependencyInjection;
namespace LanguageLearning.Core.Application.Common.ServiceCollectionManager;
public static class Initialize
{
    public static void InitApplication(this IServiceCollection services)
    {
        services.AddTransient<ICommandHandler<CreateUserProfileCommand, CreateProfileResponse>, CreateUserProfileCommandHandler>();

        services.AddValidatorsFromAssemblyContaining<IIdGenerator>(includeInternalTypes: true);

        services.AddScoped<ValidationBehavior<CreateUserProfileCommand, CreateProfileResponse>>();

    }


}
