namespace LanguageLearning.Core.Domain.Prompts.ValueObjects;
public sealed class PromptVersion : BaseValueObject
{
    public string Value { get; private set; }
    public PromptVersion(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Version cannot be empty or whitespace.");
        if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+\.\d+\.\d+$"))
            throw new ArgumentException("Version must be in format 'x.y.z' where x, y, z are numbers.");

        Value = value;
    }
    public override string ToString() => Value;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
