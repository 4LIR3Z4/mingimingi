namespace LanguageLearning.Core.Domain.Prompts.ValueObjects;
public sealed class PromptName : BaseValueObject
{
    public string Value { get; }
    public PromptName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty or whitespace.");
        if (value.Length > 100)
            throw new ArgumentException("Name cannot exceed 100 characters.");

        Value = value;
    }
    public override string ToString() => Value;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
