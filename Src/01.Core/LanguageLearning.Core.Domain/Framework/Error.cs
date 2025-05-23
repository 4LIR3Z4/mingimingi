﻿namespace LanguageLearning.Core.Domain.Framework;
public sealed record Error(string Code, string Description)
{

    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");

    public override string? ToString()
    {
        return Description;
    }
}
