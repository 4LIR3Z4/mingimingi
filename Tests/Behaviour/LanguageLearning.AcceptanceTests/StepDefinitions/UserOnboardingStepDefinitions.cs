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
            _onboardingRequest = new OnboardingRequestDto();
        }

        [Given(@"a valid {string} is provided")]
        public void GivenAValidSSOTokenIsProvided(string token)
        {
            var userIdentityFromSSO = _identityService.ValidateSSOToken(token);
        }

        [When("I provide the following profile details:")]
        public void WhenIProvideTheFollowingProfileDetails(DataTable dataTable)
        {
            _onboardingRequest = dataTable.CreateInstance<OnboardingRequestDto>();
        }

        [Then("my profile should be created successfully")]
        public async Task ThenMyProfileShouldBeCreatedSuccessfullyAsync()
        {
            _onboardingResponse = await _onboardingService.OnboardUserAsync(_onboardingRequest);
            Assert.True(_onboardingResponse.IsSuccess);
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

    internal interface IIdentityService
    {
        object ValidateSSOToken(string token);
    }

    public enum GenderType
    {
        male,
        female,
        other
    }
    public class OnboardingRequestDto
    {

        public string SSOToken { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int Age { get; internal set; }
        public GenderType Gender { get; internal set; }
        public string NativeLanguage { get; internal set; }
        public List<string> Hobbies { get; internal set; }
        public List<string> LearningGoals { get; internal set; }
        public string SkillProficiency { get; internal set; }
        public List<string> LearningPreferences { get; internal set; }
        public int StudyTimePerWeek { get; internal set; }
        public bool ExamParticipation { get; internal set; }
        public string CountryOfOrigin { get; internal set; }
        public string CurrentCountry { get; internal set; }
        public List<string> Interests { get; internal set; }
    }
    public class OnboardingResponseDto
    {
        public bool IsSuccess { get; internal set; }
    }

    public interface IOnboardingService
    {
        Task<OnboardingResponseDto> OnboardUserAsync(OnboardingRequestDto onboardingRequest);
    }
}
