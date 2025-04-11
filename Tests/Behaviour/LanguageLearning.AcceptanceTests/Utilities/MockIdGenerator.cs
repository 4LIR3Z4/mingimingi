using LanguageLearning.Core.Application.Common.Abstractions;

namespace LanguageLearning.AcceptanceTests.Utilities;
internal class MockIdGenerator : IIdGenerator
{
    public long GenerateId()
    {
        return new Random().NextInt64();
    }
}
