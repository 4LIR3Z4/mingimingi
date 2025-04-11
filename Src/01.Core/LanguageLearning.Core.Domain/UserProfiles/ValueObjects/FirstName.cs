using LanguageLearning.Core.Domain.UserProfiles.Constants;

namespace LanguageLearning.Core.Domain.UserProfiles.ValueObjects;
public sealed class FirstName : BaseValueObject
{
    public string Value { get; private set; }
    public FirstName(string input)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(input, nameof(FirstName));
        Value = input!.Trim();
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
