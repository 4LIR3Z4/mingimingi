using LanguageLearning.Core.Domain.UserProfiles.Constants;

namespace LanguageLearning.Core.Domain.UserProfiles.ValueObjects;
public sealed class Age : BaseValueObject
{
    public int Value { get; private set; }
    public Age(int value)
    {
        if (value <= UserProfileConstant.AgeMinValue || value > UserProfileConstant.AgeMaxValue) // Example validation
        {
            throw new ArgumentOutOfRangeException(nameof(Value), "Age must be a valid age.");
        }
        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
