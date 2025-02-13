using LanguageLearning.Core.Domain.UserProfiles.Constants;

namespace LanguageLearning.Core.Domain.SharedKernel.Entities;
public sealed class Language : BaseEntity<int>
{
    public string Name { get; init; }
    public string Code { get; init; }
    private Language(string name, string code)
    {
        Name = name;
        Code = code;
    }
    private Language() { }
    public static Language Create(string name, string code)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Language name cannot be null or empty.", nameof(name));

        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Language code cannot be null or empty.", nameof(code));

        if (code.Length != LanguageConstants.CodeLength)
            throw new ArgumentException($"Language code must be exactly {LanguageConstants.CodeLength} characters long.", nameof(code));
        if (name.Length < LanguageConstants.NameMinLength)
            throw new ArgumentException($"Language name must be at least {LanguageConstants.NameMinLength} characters long.", nameof(name));
        if (name.Length > LanguageConstants.NameMaxLength)
            throw new ArgumentException($"Language name must be at most {LanguageConstants.NameMaxLength} characters long.", nameof(name));

        return new Language(name.Trim(), code.Trim().ToUpperInvariant());
    }
    public override string ToString()
    {
        return $"{Name} ({Code})";
    }
}
