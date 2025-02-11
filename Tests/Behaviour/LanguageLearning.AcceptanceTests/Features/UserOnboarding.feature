Feature: User Onboarding
  As a prospective language learner
  I want to sign up using my existing SSO account and complete my profile with detailed personal information
  So that I can receive a tailored language learning experience

  # -----------------------------------------------------------------
  # Successful Onboarding Scenarios
  # -----------------------------------------------------------------
  
Scenario: Successful onboarding with complete profile details via SSO
    Given I sign in using my SSO account
    When I provide the following profile details:
        | Field               | Value            |
        | FirstName           | Alice            |
        | LastName            | Johnson          |
        | Age                 | 25               |
        | Gender              | Female           |
        | NativeLanguage      | English          |
        | Hobbies             | Reading, Cycling |
        | LearningGoals       | Achieve fluency  |
        | SkillProficiency    | Intermediate     |
        | LearningPreferences | Visual, Evening  |
        | StudyTimePerWeek    | 8                |
        | ExamParticipation   | Yes              |
        | CountryOfOrigin     | USA              |
        | CurrentCountry      | Canada           |
        | Interests           | Travel, Culture  |
    Then my profile should be created successfully
    And the response includes a success message

    
Scenario: Successful onboarding when optional fields (e.g., Hobbies and Interests) are omitted
    Given I sign in using my SSO account
    When I provide the following profile details:
        | Field               | Value           |
        | FirstName           | Bob             |
        | LastName            | Smith           |
        | Age                 | 30              |
        | Gender              | Male            |
        | NativeLanguage      | Spanish         |
        | Hobbies             | Reading         |
        | LearningGoals       | Casual learning |
        | SkillProficiency    | Beginner        |
        | LearningPreferences |                 |
        | StudyTimePerWeek    | 5               |
        | ExamParticipation   |                 |
        | CountryOfOrigin     |                 |
        | CurrentCountry      |                 |
        | Interests           |                 |
    Then my profile should be created successfully (using default values for omitted optional fields)
    And the response includes a success message

  # -----------------------------------------------------------------
  # Validation and Data Format Edge Cases
  # -----------------------------------------------------------------
Scenario: Onboarding fails when required fields are missing
    Given I sign in using my SSO account
    When I attempt to submit the profile details:
        | Field               | Value |
        | FirstName           |       |
        | LastName            |       |
        | Age                 |       |
        | Gender              |       |
        | NativeLanguage      |       |
        | Hobbies             |       |
        | LearningGoals       |       |
        | SkillProficiency    |       |
        | LearningPreferences |       |
        | StudyTimePerWeek    |       |
        | ExamParticipation   |       |
        | CountryOfOrigin     |       |
        | CurrentCountry      |       |
        | Interests           |       |
    Then I should see the following error messages:
        | Field            | Error Message                                |
        | FirstName        | FirstName must be provided.                  |
        | LastName         | LastName must be provided.                   |
        | Age              | Age must be a positive integer.              |
        | Gender           | Gender must be specified as Male or Female.  |
        | NativeLanguage   | NativeLanguage must be provided.             |
        | SkillProficiency | SkillProficiency must be provided.           |
        | StudyTimePerWeek | StudyTimePerWeek must be a positive integer. |
        | Interests        | At least one interest must be provided.      |
        | Hobbies          | At least one hobby must be provided.         |
    And my profile should not be created

  # -----------------------------------------------------------------
  # External SSO Integration and Duplicate Registration
  # -----------------------------------------------------------------

Scenario: Onboarding fails due to external SSO provider error
    Given I attempt to sign in using my SSO account
    When the SSO provider returns an authentication error
    Then I should see an error message indicating that SSO authentication failed
    And my profile should not be created

Scenario: Duplicate SSO registration should redirect to the existing account
    Given I already have an existing account linked to the SSO provider
    When I sign in again using my SSO account
    Then I should be notified that an account already exists
    And my profile should not be createds
