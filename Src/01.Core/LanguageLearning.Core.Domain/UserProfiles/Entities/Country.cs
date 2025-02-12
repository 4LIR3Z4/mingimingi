using LanguageLearning.Core.Domain.UserProfiles.Constants;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public class Country : BaseEntity<int>
{
    public string Name { get; private set; }
    public string IsoCode { get; private set; }
    private Country(string name, string isoCode)
    {
        Name = name;
        IsoCode = isoCode;

    }
    private Country() { }
    public static Country Create(string name, string isoCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Country name cannot be null or empty.", nameof(name));
        if (string.IsNullOrWhiteSpace(isoCode))
            throw new ArgumentException("Country code cannot be null or empty.", nameof(isoCode));
        if (name.Length < CountryConstants.NameMinLength)
            throw new ArgumentException($"Country name must be at least {CountryConstants.NameMinLength} characters long.", nameof(name));
        if (name.Length > CountryConstants.NameMaxLength)
            throw new ArgumentException($"Country name must be at most {CountryConstants.NameMaxLength} characters long.", nameof(name));
        if (isoCode.Length != CountryConstants.IsoCodeLength)
            throw new ArgumentException($"Country code must be exactly {CountryConstants.IsoCodeLength} characters long.", nameof(isoCode));
        return new Country(name.Trim(), isoCode.Trim().ToUpperInvariant());
    }
    public override string ToString()
    {
        return $"{Name} ({IsoCode})";
    }
}
