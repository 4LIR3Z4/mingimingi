using LanguageLearning.Core.Domain.SharedKernel.Constants;

namespace LanguageLearning.Core.Domain.SharedKernel.Entities;
public sealed class Hobby : BaseEntity<int>
{
    public string Name { get; private set; } = string.Empty;
    private Hobby(string name)
    {
        Name = name;
    }
    private Hobby() { }
    public static Hobby Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Hobby name cannot be null or empty.", nameof(name));

        if (name.Length > HobbyConstants.NameMaxLength)
            throw new ArgumentException($"Hobby name cannot exceed {HobbyConstants.NameMaxLength} characters.", nameof(name));
        if (name.Length < HobbyConstants.NameMinLength)
            throw new ArgumentException($"Hobby name should be at least {HobbyConstants.NameMinLength} characters.", nameof(name));

        return new Hobby(name.Trim());
    }
}
