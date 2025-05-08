using LanguageLearning.Core.Domain.Prompts.Constants;

namespace LanguageLearning.Core.Domain.Prompts.ValueObjects;
public sealed class PromptDescription : BaseValueObject
{
    public string Value { get; private set; }
    public PromptDescription(string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        if (value.Length > PromptConstants.MaxDescriptionLength)
            throw new ArgumentException($"Description cannot exceed {PromptConstants.MaxDescriptionLength} characters.");

        Value = value;
    }
    public override string ToString() => Value;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
