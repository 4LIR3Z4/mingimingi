using LanguageLearning.Architecture.Test.Shared;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;
using FluentValidation;
using NetArchTest.Rules;
using FluentAssertions;

namespace LanguageLearning.Architecture.Test.Application;
public class ApplicationTests
{
    [Fact]
    public void CommandHandler_Should_NotBePublic()
    {
        var result = Types.InAssembly(Layers.ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Or()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .NotBePublic()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void CommandHandler_ShouldHave_NameEndingWith_CommandHandler()
    {
        var result = Types.InAssembly(Layers.ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Or()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }



    [Fact]
    public void QueryHandler_ShouldHave_NameEndingWith_QueryHandler()
    {
        var result = Types.InAssembly(Layers.ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void QueryHandler_Should_NotBePublic()
    {
        var result = Types.InAssembly(Layers.ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .NotBePublic()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Validator_ShouldHave_NameEndingWith_Validator()
    {
        var result = Types.InAssembly(Layers.ApplicationAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .Should()
            .HaveNameEndingWith("Validator")
            .GetResult().IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Validator_Should_NotBePublic()
    {
        var result = Types.InAssembly(Layers.ApplicationAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .Should()
            .NotBePublic()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
    [Fact]
    public void CommandHandler_Should_BeSealed()
    {
        var result = Types.InAssembly(Layers.ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Or()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .BeSealed()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
