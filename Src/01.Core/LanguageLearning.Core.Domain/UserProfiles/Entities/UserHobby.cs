using LanguageLearning.Core.Domain.SharedKernel.Entities;

namespace LanguageLearning.Core.Domain.UserProfiles.Entities;
public sealed class UserHobby : BaseEntity<int>
{
    public Hobby Hobby { get; set; } = null!;
}