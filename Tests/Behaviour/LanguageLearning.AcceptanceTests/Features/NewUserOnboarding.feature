Feature: NewUserOnboarding
  As a new user
  I want to create a user profile
  So that I can start using the language learning platform

Scenario: Successfully create a user profile
    Given a user provides valid details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile is created
    Then the profile should be saved successfully

Scenario: Fail to create a user profile with missing required fields
    Given a user provides incomplete details:
        | Field            | Value |
        | FirstName        |       |
        | LastName         |       |
        | Age              |       |
        | Gender           |       |
        | NativeLanguageId |       |
        | CountryOfOrigin  |       |
        | CurrentCountry   |       |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "All fields are required" should be displayed

Scenario: Fail to create a user profile with invalid age
    Given a user provides invalid details:
        | Field | Value |
        | Age   | -5    |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Age must be a positive integer" should be displayed

Scenario: Fail to create a user profile with invalid first name
    Given a user provides invalid details:
        | Field     | Value |
        | FirstName | 12345 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "FirstName must be a valid string" should be displayed

Scenario: Fail to create a user profile with invalid last name
    Given a user provides invalid details:
        | Field    | Value |
        | LastName | 67890 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "LastName must be a valid string" should be displayed

Scenario: Fail to create a user profile with invalid gender
    Given a user provides invalid details:
        | Field  | Value |
        | Gender | Alien |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Gender must be one of the predefined values" should be displayed

Scenario: Fail to create a user profile with invalid native language ID
    Given a user provides invalid details:
        | Field            | Value |
        | NativeLanguageId | -1    |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "NativeLanguageId must be a positive integer" should be displayed

Scenario: Fail to create a user profile with invalid country of origin
    Given a user provides invalid details:
        | Field           | Value |
        | CountryOfOrigin | XYZ   |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "CountryOfOrigin must be a valid country" should be displayed

Scenario: Fail to create a user profile with invalid current country
    Given a user provides invalid details:
        | Field          | Value |
        | CurrentCountry | ABC   |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "CurrentCountry must be a valid country" should be displayed

Scenario: Fail to create a user profile with invalid hobbies
    Given a user provides invalid details:
        | Field   | Value        |
        | Hobbies | 123, Invalid |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Hobbies must be a list of valid hobby names" should be displayed

Scenario: Fail to create a user profile with invalid interests
    Given a user provides invalid details:
        | Field     | Value        |
        | Interests | 456, Invalid |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Interests must be a list of valid interest names" should be displayed
