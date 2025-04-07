using LanguageLearning.Core.Domain.UserProfiles.Constants;

namespace LanguageLearning.Core.Domain.UserProfiles.ValueObjects;
public sealed class Age : BaseValueObject
{
    public int Value { get; private set; }
    public Age(int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, UserProfileConstant.AgeMinValue);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, UserProfileConstant.AgeMaxValue);
        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
