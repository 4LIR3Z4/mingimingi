using System;
using Reqnroll;

namespace LanguageLearning.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UserOnboardingStepDefinitions
    {
        [Given("I sign in using my SSO account")]
        public void GivenISignInUsingMySSOAccount()
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

        [Then("the response includes a success message")]
        public void ThenTheResponseIncludesASuccessMessage()
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

        [Given("I attempt to sign in using my SSO account")]
        public void GivenIAttemptToSignInUsingMySSOAccount()
        {
            throw new PendingStepException();
        }

        [When("the SSO provider returns an authentication error")]
        public void WhenTheSSOProviderReturnsAnAuthenticationError()
        {
            throw new PendingStepException();
        }

        [Then("I should see an error message indicating that SSO authentication failed")]
        public void ThenIShouldSeeAnErrorMessageIndicatingThatSSOAuthenticationFailed()
        {
            throw new PendingStepException();
        }

        [Given("I already have an existing account linked to the SSO provider")]
        public void GivenIAlreadyHaveAnExistingAccountLinkedToTheSSOProvider()
        {
            throw new PendingStepException();
        }

        [When("I sign in again using my SSO account")]
        public void WhenISignInAgainUsingMySSOAccount()
        {
            throw new PendingStepException();
        }

        [Then("I should be notified that an account already exists")]
        public void ThenIShouldBeNotifiedThatAnAccountAlreadyExists()
        {
            throw new PendingStepException();
        }

        [Then("my profile should not be createds")]
        public void ThenMyProfileShouldNotBeCreateds()
        {
            throw new PendingStepException();
        }
    }
}
