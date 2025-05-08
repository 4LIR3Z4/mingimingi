
using LanguageLearning.Core.Domain.Prompts.Constants;

namespace LanguageLearning.Core.Domain.Prompts.ValueObjects;
public sealed class PromptTemplate : BaseValueObject
{
    public string Value { get; }

    public PromptTemplate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Template cannot be empty or whitespace.");
        if (value.Length > PromptConstants.MaxTemplateLength)
            throw new ArgumentException($"Template cannot exceed {PromptConstants.MaxTemplateLength} characters.");

        Value = value;
    }
    public override string ToString() => Value;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
