using LanguageLearning.Core.Domain.UserProfiles.Constants;

namespace LanguageLearning.Core.Domain.UserProfiles.ValueObjects;
public sealed class LastName : BaseValueObject
{
    public string Value { get; private set; }
    public LastName(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Last name cannot be null or empty.", nameof(input));
        }
        Value = input.Trim();
        if (Value.Length > UserProfileConstant.LastNameMaxLength)
        {
            throw new ArgumentException($"Last name cannot exceed {UserProfileConstant.LastNameMaxLength} characters.", nameof(Value));
        }

    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
