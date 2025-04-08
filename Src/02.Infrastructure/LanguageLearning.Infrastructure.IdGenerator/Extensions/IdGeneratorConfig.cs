using IdGen.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Infrastructure.IdGenerator.Extensions;
public static class IdGeneratorConfig
{
    public static void RegisterSnowflakeIdGeneratorService(
        this IServiceCollection services,
        int idGeneratorId)
    {
        services.AddIdGen(idGeneratorId);
    }
}
