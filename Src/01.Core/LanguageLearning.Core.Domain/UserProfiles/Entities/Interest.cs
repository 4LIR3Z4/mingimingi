﻿using LanguageLearning.Core.Domain.UserProfiles.Constants;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public class Interest : BaseEntity<int>
{
    public string Name { get; private set; }
    private Interest(string name)
    {
        Name = name;
    }
    private Interest() { }
    public static Interest Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Interest name cannot be null or empty.", nameof(name));

        if (name.Length > InterestConstants.NameMaxLength)
            throw new ArgumentException($"Interest name cannot exceed {InterestConstants.NameMaxLength} characters.", nameof(name));
        if(name.Length < InterestConstants.NameMinLength)
            throw new ArgumentException($"Interest name must be at least {InterestConstants.NameMinLength} characters.", nameof(name)); 

        return new Interest(name.Trim());
    }
}
