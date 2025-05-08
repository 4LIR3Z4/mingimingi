namespace LanguageLearning.Core.Domain.Prompts.ValueObjects;
public sealed class PromptDescription : BaseValueObject
{
    public string Value { get; private set; }
    public PromptDescription(string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        if (value.Length > 500)
            throw new ArgumentException("Description cannot exceed 500 characters.");

        Value = value;
    }
    public override string ToString() => Value;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
