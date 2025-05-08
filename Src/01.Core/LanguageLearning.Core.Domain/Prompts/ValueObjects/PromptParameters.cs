
namespace LanguageLearning.Core.Domain.Prompts.ValueObjects;
public sealed class PromptParameters : BaseValueObject
{
    public Dictionary<string, string> Value { get; }

    public PromptParameters(Dictionary<string, string> value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        if (value.Any(kvp => string.IsNullOrWhiteSpace(kvp.Key)))
            throw new ArgumentException("Parameter keys cannot be empty or whitespace.");
        if (value.Any(kvp => kvp.Value == null))
            throw new ArgumentException("Parameter values cannot be null.");

        Value = new Dictionary<string, string>(value);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
