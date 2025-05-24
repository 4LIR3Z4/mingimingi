using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.LearningJourneys.Entities;
using LanguageLearning.Core.Domain.Prompts.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LanguageLearning.AcceptanceTests.Utilities;
internal class MockDbContext : IDbContext
{
    //private readonly DbContextOptions _options = null!;

    public MockDbContext()
    {
        var mockUserProfiles = CreateMockDbSet(new List<UserProfile>
        {
            //new UserProfile { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            //new UserProfile { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        });

        UserProfiles = mockUserProfiles.Object;

        var mockHobbies = CreateMockDbSet(new List<Hobby>
        {
            //new UserProfile { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            //new UserProfile { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        });

        Hobbies = mockHobbies.Object;

        var mockCountries = CreateMockDbSet(new List<Country>
        {
            //new UserProfile { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            //new UserProfile { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        });

        Countries = mockCountries.Object;

        var mockInterests = CreateMockDbSet(new List<Interest>
        {
            //new UserProfile { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            //new UserProfile { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        });

        Interests = mockInterests.Object;

        var mockLanguages = CreateMockDbSet(new List<Language>
        {
            //new UserProfile { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            //new UserProfile { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        });

        Languages = mockLanguages.Object;

        var mockPrompts = CreateMockDbSet(new List<Prompt>
        {
            //new UserProfile { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            //new UserProfile { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        });

        Prompts = mockPrompts.Object;

        var mockLearningJourney = CreateMockDbSet(new List<LearningJourney>
        {
            //new UserProfile { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            //new UserProfile { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
        });

        LearningJourneys = mockLearningJourney.Object;
    }

    public DbSet<UserProfile> UserProfiles { get; set; } = null!;
    public DbSet<Hobby> Hobbies { get; set; } = null!;
    public DbSet<Interest> Interests { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Prompt> Prompts { get; set; } = null!;
    public DbSet<LearningJourney> LearningJourneys { get; set; } = null!;

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