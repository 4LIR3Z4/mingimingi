Feature: User Onboarding
  As a prospective language learner
  I want to sign up using my existing SSO account and complete my profile with detailed personal information
  So that I can receive a tailored language learning experience

  # -----------------------------------------------------------------
  # Successful Onboarding Scenarios
  # -----------------------------------------------------------------
  
Scenario: Successful onboarding with complete profile details via SSO
    Given a valid "SSO token" is provided
    When I provide the following profile details:
        | Field                            | Value            |
        | FirstName                        | Alice            |
        | LastName                         | Johnson          |
        | Age                              | 25               |
        | Gender                           | Female           |
        | NativeLanguage                   | Farsi            |
        | Hobbies                          | Reading, Cycling |
        | CountryOfOrigin                  | United States    |
        | CurrentCountry                   | Canada           |
        | Interests                        | Travel, Culture  |
        | LearningLanguage                 | English          |
        | LearningLanguageProficiencyLevel | Beginner         |
    Then my profile should be created successfully
    

  # -----------------------------------------------------------------
  # Validation and Data Format Edge Cases
  # -----------------------------------------------------------------
Scenario: Onboarding fails when required fields are missing
    Given a valid "SSO token" is provided
    When I attempt to submit the profile details:
        | Field                            | Value |
        | FirstName                        |       |
        | LastName                         |       |
        | Age                              |       |
        | Gender                           |       |
        | NativeLanguage                   |       |
        | Hobbies                          |       |
        | CountryOfOrigin                  |       |
        | CurrentCountry                   |       |
        | Interests                        |       |
        | LearningLanguage                 |       |
        | LearningLanguageProficiencyLevel |       |
    Then I should see the following error messages:
        | Field                            | Error Message                                |
        | FirstName                        | FirstName must be provided.                  |
        | LastName                         | LastName must be provided.                   |
        | Age                              | Age must be a positive integer.              |
        | Gender                           | Gender must be specified as Male or Female.  |
        | NativeLanguage                   | NativeLanguage must be provided.             |
        | Interests                        | At least one interest must be provided.      |
        | Hobbies                          | At least one hobby must be provided.         |
        | LearningLanguage                 | LearningLanguage is Required                 |
        | LearningLanguageProficiencyLevel | LearningLanguageProficiencyLevel is Required |
    And my profile should not be created

  # -----------------------------------------------------------------
  # External SSO Integration and Duplicate Registration
  # -----------------------------------------------------------------

Scenario: Onboarding fails due to invalid SSO token
    Given an invalid SSO token is provided
    Then I should see an error message with 401 code
    And my profile should not be created
