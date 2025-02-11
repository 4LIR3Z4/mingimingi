using FluentAssertions;
using NetArchTest.Rules;

namespace LanguageLearning.Architecture.Test.Application;
public class GeneralTests
{
    [Fact]
    public void InterfaceNames_Should_StartWithAnI()
    {
        var result = Types.InCurrentDomain()
                .That().AreInterfaces()
                .Should()
                .HaveNameStartingWith("I")
                .GetResult();
        result.IsSuccessful.Should().BeTrue();

    }
}
