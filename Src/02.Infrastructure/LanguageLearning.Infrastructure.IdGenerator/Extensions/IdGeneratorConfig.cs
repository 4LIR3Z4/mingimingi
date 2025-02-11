using LanguageLearning.Core.Application.Common.Abstractions;
using IdGen.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Infrastructure.IdGenerator.Extensions;
public static class IdGeneratorConfig
{
    public static IServiceCollection RegisterSnowflakeIdGeneratorService(
        this IServiceCollection services,
        int idGeneratorId)
    {
        services.AddIdGen(idGeneratorId);
        services.AddSingleton<IIdGenerator, SnowflakeIdGenerator>();
        return services;
    }
}
