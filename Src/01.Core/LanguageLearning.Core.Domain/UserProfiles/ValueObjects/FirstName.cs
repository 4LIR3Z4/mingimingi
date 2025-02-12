using LanguageLearning.Core.Domain.UserProfiles.Constants;

namespace LanguageLearning.Core.Domain.UserProfiles.ValueObjects;
public sealed class FirstName : BaseValueObject
{
    public string Value { get; private set; }
    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            throw new ArgumentException("First name cannot be null or empty.", nameof(Value));
        }
        Value = Value.Trim();
        if (Value.Length > UserProfileConstant.FirstNameMaxLength)
        {
            throw new ArgumentException($"First name cannot exceed {UserProfileConstant.FirstNameMaxLength} characters.", nameof(Value));
        }

    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
