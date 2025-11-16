using LanguageLearning.Core.Domain.SharedKernel.Entities;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public sealed class UserInterest : BaseEntity<int>
{
    public Interest Interest { get; init; } = null!;
}
