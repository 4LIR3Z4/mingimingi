using LanguageLearning.Architecture.Test.Shared;
using LanguageLearning.Presentation.API.Framework;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetArchTest.Rules;
using System.Linq;
using System.Reflection;

namespace LanguageLearning.Architecture.Test.Api;
public class ApiLayerTests
{
    [Fact]
    public void Controllers_Should_Have_Return_Type_Of_Results()
    {
        var result = Types.InAssembly(Layers.PresentationAssembly)
            .That()
            .AreClasses()
            .And()
            .ResideInNamespace("LanguageLearning.Presentation.API.Controllers.*").Or()
            .ResideInNamespace("LanguageLearning.Presentation.API.Controllers")

            .GetTypes();
        foreach (var type in result)
        {
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            foreach (var item in methods)
            {
                Console.WriteLine(item.Name);
                item.ReturnType.ToString().Should().StartWith("Microsoft.AspNetCore.Http.HttpResults.Results");
            }
        }
    }
    [Fact]
    public void Controllers_Should_Inherit_From_BaseController()
    {
        var result = Types.InAssembly(Layers.PresentationAssembly)
            .That()
            .AreClasses()
            .And()
            .ResideInNamespace("LanguageLearning.Presentation.API.Controllers.*").Or()
            .ResideInNamespace("LanguageLearning.Presentation.API.Controllers")
            .Should()
            .Inherit(typeof(BaseController)).GetResult().IsSuccessful.Should().BeTrue();
    }
    [Fact]
    public void Controllers_Should_Be_sealed()
    {
        var result = Types.InAssembly(Layers.PresentationAssembly)
            .That()
            .AreClasses()
            .And()
            .ResideInNamespace("LanguageLearning.Presentation.API.Controllers.*").Or()
            .ResideInNamespace("LanguageLearning.Presentation.API.Controllers")
            .Should()
            .BeSealed().GetResult().IsSuccessful.Should().BeTrue();
    }
}
