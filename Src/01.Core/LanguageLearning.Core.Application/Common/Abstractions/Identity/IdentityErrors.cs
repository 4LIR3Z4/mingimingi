namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public sealed class IdentityErrors
{
    public static readonly Error RegistrationFailedError = new("Identity.RegistrationFailed", "User registration failed at the identity provider");
    public static readonly Error InvalidResponseError = new("Identity.InvalidResponse", "Identity provider response missing required subject identifier");
    public static readonly Error ExceptionError = new("Identity.Exception", "An exception occurred during user registration");

}
