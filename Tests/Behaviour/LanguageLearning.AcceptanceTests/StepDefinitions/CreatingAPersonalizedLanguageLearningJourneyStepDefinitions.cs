using LanguageLearning.AcceptanceTests.Utilities;
using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.Common.Abstractions.Identity;
using LanguageLearning.Core.Application.Common.Extensions;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Infrastructure.Caching.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.AcceptanceTests.StepDefinitions;

[Binding]
public class CreatingAPersonalizedLanguageLearningJourneyStepDefinitions
{
    private readonly IIdentityService _identityService;
    private readonly IDbContext _dbContext;
    private readonly ICommandDispatcher _commandDispatcher;

    public CreatingAPersonalizedLanguageLearningJourneyStepDefinitions()
    {
        var serviceCollection = new ServiceCollection();
        DependencyInjection.InitApplication(serviceCollection);
        CacheConfig.ConfigureCaching(serviceCollection);
        var serviceProvider = serviceCollection
            .AddScoped<IDbContext, MockDbContext>()
            .AddScoped<IIdentityService, MockIdentity>()
            .AddScoped<ICommandDispatcher, CommandDispatcher>()
            .AddSingleton(TimeProvider.System)
            .BuildServiceProvider();

        _identityService = serviceProvider.GetRequiredService<IIdentityService>();
        _dbContext = serviceProvider.GetRequiredService<IDbContext>();
        _commandDispatcher = serviceProvider.GetRequiredService<ICommandDispatcher>();
    }

    [Given("I am logged into the language learning application")]
    public void GivenIAmLoggedIntoTheLanguageLearningApplication()
    {
        
    }

    [When("I select {string} as my target language")]
    public void WhenISelectAsMyTargetLanguage(string language)
    {
        throw new PendingStepException();
    }

    [When("I choose {string} as my learning target")]
    public void WhenIChooseAsMyLearningTarget(string target)
    {
        throw new PendingStepException();
    }

    [When("I create learning goals for each skill type:")]
    public void WhenICreateLearningGoalsForEachSkillType(DataTable goals)
    {
        throw new PendingStepException();
    }

    [When("I provide my initial proficiency assessment:")]
    public void WhenIProvideMyInitialProficiencyAssessment(DataTable proficiency)
    {
        throw new PendingStepException();
    }

    [When("I submit my learning journey request")]
    public void WhenISubmitMyLearningJourneyRequest()
    {
        throw new PendingStepException();
    }

    [Then("the system should create a new Learning Journey")]
    public void ThenTheSystemShouldCreateANewLearningJourney()
    {
        throw new PendingStepException();
    }

    [Then("the system should generate a personalized Learning Path")]
    public void ThenTheSystemShouldGenerateAPersonalizedLearningPath()
    {
        throw new PendingStepException();
    }

    [Then("the Learning Path should contain at least one Learning Sessions")]
    public void ThenTheLearningPathShouldContainAtLeastOneLearningSessions()
    {
        throw new PendingStepException();
    }
    [Then("each Learning Session should have at least one Learning Content")]
    public void ThenEachLearningSessionShouldHaveAtLeastOneLearningContent()
    {
        throw new PendingStepException();
    }
    [Then("each Learning Session should have at least one Assessment Item")]
    public void ThenEachLearningSessionShouldHaveAtLeastOneAssessmentItem()
    {
        throw new PendingStepException();
    }

    [Then("I should be notified that my Learning Journey has been created successfully")]
    public void ThenIShouldBeNotifiedThatMyLearningJourneyHasBeenCreatedSuccessfully()
    {
        throw new PendingStepException();
    }

    [Given("I have an active Learning Journey for {string}")]
    public void GivenIHaveAnActiveLearningJourneyFor(string spanish)
    {
        throw new PendingStepException();
    }

    [Given("my Learning Path has multiple Learning Sessions")]
    public void GivenMyLearningPathHasMultipleLearningSessions()
    {
        throw new PendingStepException();
    }

    [When("I complete all content and assessments in the current Learning Session")]
    public void WhenICompleteAllContentAndAssessmentsInTheCurrentLearningSession()
    {
        throw new PendingStepException();
    }

    [Then("the system should mark the session as {string}")]
    public void ThenTheSystemShouldMarkTheSessionAs(string completed)
    {
        throw new PendingStepException();
    }

    [Then("I should be able to proceed to the next Learning Session in the path")]
    public void ThenIShouldBeAbleToProceedToTheNextLearningSessionInThePath()
    {
        throw new PendingStepException();
    }

    [Then("my progress should be tracked and visible")]
    public void ThenMyProgressShouldBeTrackedAndVisible()
    {
        throw new PendingStepException();
    }

    [When("I choose to skip the current Learning Session")]
    public void WhenIChooseToSkipTheCurrentLearningSession()
    {
        throw new PendingStepException();
    }

    [Then("the system should allow me to access the next Learning Session")]
    public void ThenTheSystemShouldAllowMeToAccessTheNextLearningSession()
    {
        throw new PendingStepException();
    }

    [Then("the skipped session should be marked accordingly")]
    public void ThenTheSkippedSessionShouldBeMarkedAccordingly()
    {
        throw new PendingStepException();
    }

    [Then("I should be informed that skipping may affect my overall learning progress")]
    public void ThenIShouldBeInformedThatSkippingMayAffectMyOverallLearningProgress()
    {
        throw new PendingStepException();
    }

    [Given("I have completed or skipped all Learning Sessions in my current path")]
    public void GivenIHaveCompletedOrSkippedAllLearningSessionsInMyCurrentPath()
    {
        throw new PendingStepException();
    }

    [When("I finish the final session in the path")]
    public void WhenIFinishTheFinalSessionInThePath()
    {
        throw new PendingStepException();
    }

    [Then("the system should mark the Learning Path as {string}")]
    public void ThenTheSystemShouldMarkTheLearningPathAs(string completed)
    {
        throw new PendingStepException();
    }

    [Then("I should be presented with an option to generate a new Learning Path")]
    public void ThenIShouldBePresentedWithAnOptionToGenerateANewLearningPath()
    {
        throw new PendingStepException();
    }

    [Then("my proficiency levels should be reassessed")]
    public void ThenMyProficiencyLevelsShouldBeReassessed()
    {
        throw new PendingStepException();
    }

    [Given("I have an active Learning Journey for Spanish")]
    public void GivenIHaveAnActiveLearningJourneyForSpanish()
    {
        throw new PendingStepException();
    }

    [When("I choose to abandon my current Learning Path")]
    public void WhenIChooseToAbandonMyCurrentLearningPath()
    {
        throw new PendingStepException();
    }

    [Then("the system should mark the path as {string}")]
    public void ThenTheSystemShouldMarkThePathAs(string abandoned)
    {
        throw new PendingStepException();
    }

    [Then("I should be offered options to:")]
    public void ThenIShouldBeOfferedOptionsTo(DataTable dataTable)
    {
        throw new PendingStepException();
    }

    [Given("I have an existing Learning Journey for Spanish")]
    public void GivenIHaveAnExistingLearningJourneyForSpanish()
    {
        throw new PendingStepException();
    }

    [When("I update my learning goals:")]
    public void WhenIUpdateMyLearningGoals(DataTable dataTable)
    {
        throw new PendingStepException();
    }

    [When("I request a new Learning Path")]
    public void WhenIRequestANewLearningPath()
    {
        throw new PendingStepException();
    }

    [Then("the system should generate a new path based on my updated goals")]
    public void ThenTheSystemShouldGenerateANewPathBasedOnMyUpdatedGoals()
    {
        throw new PendingStepException();
    }

    [Then("my Learning Journey should maintain my proficiency history")]
    public void ThenMyLearningJourneyShouldMaintainMyProficiencyHistory()
    {
        throw new PendingStepException();
    }

    [Then("the new path should reflect my adjusted priorities")]
    public void ThenTheNewPathShouldReflectMyAdjustedPriorities()
    {
        throw new PendingStepException();
    }
}