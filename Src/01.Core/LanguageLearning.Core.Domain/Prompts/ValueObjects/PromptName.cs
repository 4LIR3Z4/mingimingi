using LanguageLearning.Core.Domain.Prompts.Constants;

namespace LanguageLearning.Core.Domain.Prompts.ValueObjects;
public sealed class PromptName : BaseValueObject
{
    public string Value { get; }
    public PromptName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty or whitespace.");
        if (value.Length > PromptConstants.MaxNameLength)
            throw new ArgumentException($"Name cannot exceed {PromptConstants.MaxNameLength} characters.");

        Value = value;
    }
    public override string ToString() => Value;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
