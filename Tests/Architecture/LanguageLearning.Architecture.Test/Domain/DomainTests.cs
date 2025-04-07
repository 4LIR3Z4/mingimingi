using LanguageLearning.Architecture.Test.Shared;
using LanguageLearning.Core.Domain.Framework;
using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;
using LanguageLearning.Core.Domain.Framework.Events;
namespace LanguageLearning.Architecture.Test.Domain;
public class DomainTests
{

    [Fact]
    public void DomainEvents_Should_BeSealed()
    {
        TestResult result = Types.InAssembly(Layers.DomainAssembly)
            .That()
            .Inherit(typeof(IDomainEvent))
            .Should()
            .BeSealed()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainEvent_ShouldHave_DomainEventPostfix()
    {
        var result = Types.InAssembly(Layers.DomainAssembly)
            .That()
            .Inherit(typeof(IDomainEvent))
            .Should()
            .HaveNameEndingWith("Event")
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Entities_ShouldHave_PrivateParameterlessConstructor()
    {
        IEnumerable<Type> entityTypes = Types.InAssembly(Layers.DomainAssembly)
            .That()
            .Inherit(typeof(BaseEntity<>))
            .And()
            .AreNotAbstract()
            .GetTypes();

        var failingTypes = new List<Type>();
        foreach (Type entityType in entityTypes)
        {
            ConstructorInfo[] constructors = entityType.GetConstructors(BindingFlags.NonPublic |
                                                                        BindingFlags.Instance);

            if (!constructors.Any(c => c.IsPrivate && c.GetParameters().Length == 0))
            {
                failingTypes.Add(entityType);
            }
        }

        failingTypes.Should().BeEmpty();
    }
    [Fact]
    public void Entities_Should_Have_PrivateSetter()
    {
        var entityTypes = Types.InAssembly(Layers.DomainAssembly)
            .That()
            .AreClasses()
            .And()
            .Inherit(typeof(BaseEntity<>))
            .GetTypes();

        foreach (var entityType in entityTypes)
        {
            var properties = entityType.GetProperties();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetMethod.Should().NotBeNull()
                        .And.Match(setMethod => setMethod.IsPrivate || setMethod.IsFamily || setMethod.IsFamilyOrAssembly,
                            $"{property.Name} should have a private or protected setter.", property.DeclaringType?.FullName);
                }
            }
        }
    }
}
