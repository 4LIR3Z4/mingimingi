using LanguageLearning.Architecture.Test.Shared;
using FluentValidation;
using NetArchTest.Rules;
using FluentAssertions;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Queries;

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

    [Fact]
    public void Each_ICommand_Should_Have_Exactly_One_AbstractValidator()
    {
        var applicationAssembly = Layers.ApplicationAssembly;
        var commandTypes = Types.InAssembly(applicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommand<>))
            .GetTypes();

        var validatorTypes = Types.InAssembly(applicationAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .GetTypes();

        foreach (var commandType in commandTypes)
        {
            var matchingValidators = validatorTypes
                .Where(v =>
                    v.BaseType is { IsGenericType: true }
                    && v.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>)
                    && v.BaseType.GetGenericArguments()[0] == commandType
                )
                .ToList();

            matchingValidators.Count.Should().Be(1, $"Command '{commandType.Name}' should have exactly one AbstractValidator");
        }
    }
}
