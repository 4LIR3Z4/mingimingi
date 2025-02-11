using System;
using Reqnroll;

namespace LanguageLearning.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UserOnboardingStepDefinitions
    {
        [Given("a valid SSO token is provided")]
        public void GivenAValidSSOTokenIsProvided()
        {
            throw new PendingStepException();
        }

        [When("I provide the following profile details:")]
        public void WhenIProvideTheFollowingProfileDetails(DataTable dataTable)
        {
            throw new PendingStepException();
        }

        [Then("my profile should be created successfully")]
        public void ThenMyProfileShouldBeCreatedSuccessfully()
        {
            throw new PendingStepException();
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
}
