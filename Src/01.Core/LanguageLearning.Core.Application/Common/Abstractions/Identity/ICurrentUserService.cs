namespace LanguageLearning.Core.Application.Common.Abstractions.Identity;
public interface ICurrentUserService
{
    bool IsAuthenticated { get; }
    long? UserId { get; }
}
