using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LanguageLearning.AcceptanceTests.Utilities;
internal class MockDbContext : IDbContext
{
    private readonly DbContextOptions _options;

    public MockDbContext()
    {
        var mockUserProfiles = CreateMockDbSet(new List<UserProfile>
        {
            //new UserProfile { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            //new UserProfile { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        });

        UserProfiles = mockUserProfiles.Object;
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Country> Countries { get; set; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken); // Simulate async work
        return 1; // Return the number of entities saved (mocked as 1 for simplicity)
    }

    private static Mock<DbSet<T>> CreateMockDbSet<T>(List<T> data) where T : class
    {
        var queryable = data.AsQueryable();

        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

        mockSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(data.Add);

        return mockSet;
    }
}