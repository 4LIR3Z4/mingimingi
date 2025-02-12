using LanguageLearning.Core.Domain.UserProfiles.Entities;

namespace LanguageLearning.Core.Application.Common.Abstractions;
public interface IDbContext
{
    public DbSet<UserProfile> userProfiles { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
