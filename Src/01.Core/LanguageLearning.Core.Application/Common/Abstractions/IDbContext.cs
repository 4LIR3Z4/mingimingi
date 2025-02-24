using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Entities;

namespace LanguageLearning.Core.Application.Common.Abstractions;
public interface IDbContext
{
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Country> Countries { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
