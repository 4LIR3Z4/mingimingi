using LanguageLearning.Core.Domain.SharedKernel.Entities;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public sealed class UserHobby : BaseEntity<int>
{
    public UserProfile UserProfile { get; set; }
    public Hobby Hobby { get; set; }
}