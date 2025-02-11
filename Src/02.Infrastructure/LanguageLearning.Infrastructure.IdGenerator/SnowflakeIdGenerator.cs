using LanguageLearning.Core.Application.Common.Abstractions;

namespace LanguageLearning.Infrastructure.IdGenerator;
public class SnowflakeIdGenerator(IdGen.IdGenerator generator) : IIdGenerator
{
    private readonly IdGen.IdGenerator _generator = generator;
    public long GenerateId()
    {
        return _generator.CreateId();

    }
}
