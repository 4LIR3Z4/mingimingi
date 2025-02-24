

using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Domain.Framework;
using LanguageLearning.Core.Domain.Languages.Entities;
using LanguageLearning.Core.Domain.SharedKernel.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Entities;
using LanguageLearning.Core.Domain.UserProfiles.Enums;
using LanguageLearning.Infrastructure.IdGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace LanguageLearning.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UserOnboardingStepDefinitions
    {
        private readonly IOnboardingService _onboardingService;
        private readonly IIdentityService _identityService;
        private OnboardingRequestDto _onboardingRequest;
        private OnboardingResponseDto _onboardingResponse;

        public UserOnboardingStepDefinitions()
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IDbContext, MockDbContext>()
                .AddScoped<IIdentityService, MockIdentityService>()
                .AddScoped<IOnboardingService, OnboardingService>()
                .AddScoped<IIdGenerator, SnowflakeIdGenerator>()
                .BuildServiceProvider();

            _identityService = serviceProvider.GetRequiredService<IIdentityService>();
            _onboardingService = serviceProvider.GetRequiredService<IOnboardingService>();

            _onboardingRequest = new OnboardingRequestDto();
        }

        [Given(@"a valid {string} is provided")]
        public async Task GivenAValidSSOTokenIsProvided(string token)
        {
            var userIdentityFromSSO = await _identityService.ValidateSSOToken(token);
            Assert.True(userIdentityFromSSO.IsSuccess);
        }

        [When("I provide the following profile details:")]
        public void WhenIProvideTheFollowingProfileDetails(DataTable dataTable)
        {
            _onboardingRequest = dataTable.CreateInstance<OnboardingRequestDto>();
        }

        [Then("my profile should be created successfully")]
        public async Task ThenMyProfileShouldBeCreatedSuccessfullyAsync()
        {
            var response = await _onboardingService.OnboardUserAsync(_onboardingRequest);
            _onboardingResponse = response.Value;
            Assert.True(response.IsSuccess);
            Assert.True(_onboardingResponse.Id > 0);
        }

        [Then("my profile should be created successfully \\(using default values for omitted optional fields)")]
        public void ThenMyProfileShouldBeCreatedSuccessfullyUsingDefaultValuesForOmittedOptionalFields()
        {
            throw new PendingStepException();
        }

        [When("I attempt to submit the profile details:")]
        public void WhenIAttemptToSubmitTheProfileDetails(DataTable dataTable)
        {
            throw new PendingStepException();
        }

        [Then("I should see the following error messages:")]
        public void ThenIShouldSeeTheFollowingErrorMessages(DataTable dataTable)
        {
            throw new PendingStepException();
        }

        [Then("my profile should not be created")]
        public void ThenMyProfileShouldNotBeCreated()
        {
            throw new PendingStepException();
        }

        [Given("an invalid SSO token is provided")]
        public void GivenAnInvalidSSOTokenIsProvided()
        {
            throw new PendingStepException();
        }

        [Then("I should see an error message with {int} code")]
        public void ThenIShouldSeeAnErrorMessageWithCode(int p0)
        {
            throw new PendingStepException();
        }


    }

    public class OnboardingService : IOnboardingService
    {
        private readonly IDbContext _dbContext;
        private readonly IIdentityService _identityService;
        private readonly IIdGenerator _idGenerator;
        public OnboardingService(IDbContext dbContext, IIdentityService identityService,IIdGenerator idGenerator)
        {
            _dbContext = dbContext;
            _identityService = identityService;
            _idGenerator = idGenerator;
        }

        public async Task<Result<OnboardingResponseDto>> OnboardUserAsync(OnboardingRequestDto onboardingRequest)
        {
            var y = _identityService.ValidateSSOToken(onboardingRequest.SSOToken);
            //UserProfile entity = new UserProfile() { Id = _idGenerator.GenerateId(), Email = "", Name = "" };
            //_dbContext.userProfiles.Add(entity);
            //var x = await _dbContext.SaveChangesAsync();
            return Result.Success<OnboardingResponseDto>(new OnboardingResponseDto(1));

        }
    }

    public class MockDbContext : IDbContext
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


    public class MockIdentityService : IIdentityService
    {
        private readonly bool _authenticationResult;

        public MockIdentityService(bool authenticationResult = true) // Constructor to control mock behavior
        {
            _authenticationResult = authenticationResult;
        }
        public async Task<Result<bool>> ValidateSSOToken(string token)
        {
            if (_authenticationResult)
                return Result.Success<bool>(true);

            return Result.Failure<bool>(new Error("", ""));
        }
    }

    public class OnboardingRequestDto
    {

        public required string SSOToken { get; init; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int Age { get; internal set; }
        public GenderType Gender { get; internal set; }
        public string NativeLanguage { get; internal set; }
        public List<string> Hobbies { get; internal set; }
        public List<string> LearningGoals { get; internal set; }
        public string SkillProficiency { get; internal set; }
        public List<string> LearningPreferences { get; internal set; }
        public int StudyTimePerDay { get; internal set; }
        public bool ExamParticipation { get; internal set; }
        public string CountryOfOrigin { get; internal set; }
        public string CurrentCountry { get; internal set; }
        public List<string> Interests { get; internal set; }
    }
    public record OnboardingResponseDto(long Id);


    public interface IOnboardingService
    {
        Task<Result<OnboardingResponseDto>> OnboardUserAsync(OnboardingRequestDto onboardingRequest);
    }
}
