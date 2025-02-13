using LanguageLearning.Core.Domain.SharedKernel.Entities;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public sealed class UserInterest : BaseEntity<int>
{
    public UserProfile UserProfile { get; set; } = null!;
    public Interest Interest { get; set; } = null!;
}
