using LanguageLearning.Core.Domain.UserProfiles.Constants;

namespace LanguageLearning.Core.Domain.UserProfiles.ValueObjects;
public sealed class Birthdate : BaseValueObject
{
    public DateTime Value { get; private set; }
    public Birthdate(DateTime value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(CalculateAge(value), UserProfileConstant.AgeMinValue);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(CalculateAge(value), UserProfileConstant.AgeMaxValue);
        Value = value;
    }
    public int GetAge()
    {
        return CalculateAge(Value);
    }
    private int CalculateAge(DateTime birthdate)
    {
        var today = DateTime.UtcNow;
        var age = today.Year - birthdate.Year;

        if (birthdate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
