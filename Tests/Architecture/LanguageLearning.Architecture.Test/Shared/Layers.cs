using FluentAssertions;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers;
using LanguageLearning.Core.Domain.Framework.Events;
using LanguageLearning.Infrastructure.Persistence.DataContext;
using LanguageLearning.Presentation.API.ServiceCollectionManager;
using NetArchTest.Rules;
using System.Reflection;

namespace LanguageLearning.Architecture.Test.Shared;
public sealed class Layers
{
    public static readonly Assembly ApplicationAssembly = typeof(ICommand).Assembly;
    public static readonly Assembly DomainAssembly = typeof(IDomainEvent).Assembly;
    public static readonly Assembly InfrastructurePersistenceAssembly = typeof(DefaultDbContext).Assembly;
    public static readonly Assembly PresentationAssembly = typeof(InfrastructureCollectionManager).Assembly;

    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_ApplicationLayer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructurePersistenceAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructurePersistenceAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_PresentationLayer()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureLayer_ShouldNotHaveDependencyOn_PresentationLayer()
    {
        var result = Types.InAssembly(InfrastructurePersistenceAssembly)
            .Should()
            .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
