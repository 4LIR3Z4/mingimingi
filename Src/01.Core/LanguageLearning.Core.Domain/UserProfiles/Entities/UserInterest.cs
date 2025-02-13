using LanguageLearning.Core.Domain.SharedKernel.Entities;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public sealed class UserInterest : BaseEntity<int>
{
    public UserProfile UserProfile { get; set; }
    public Interest Interest { get; set; }
}
