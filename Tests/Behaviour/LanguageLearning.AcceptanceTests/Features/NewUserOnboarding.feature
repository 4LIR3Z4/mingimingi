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

Scenario: Fail to create a user profile with missing first name
    Given a user provides incomplete details:
        | Field            | Value   |
        | FirstName        |         |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "FirstName is required" should be displayed

Scenario: Fail to create a user profile with missing last name
    Given a user provides incomplete details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         |         |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "LastName is required" should be displayed

Scenario: Fail to create a user profile with missing hobbies
    Given a user provides incomplete details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          |         |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "At least one hobby must be provided" should be displayed

Scenario: Fail to create a user profile with missing interests
    Given a user provides incomplete details:
        | Field            | Value |
        | FirstName        | John  |
        | LastName         | Doe   |
        | Age              | 25    |
        | Gender           | 0     |
        | NativeLanguageId | 1     |
        | CountryOfOrigin  | 1     |
        | CurrentCountry   | 1     |
        | Hobbies          | 2, 4  |
        | Interests        |       |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "At least one interest must be provided" should be displayed

Scenario: Fail to create a user profile with invalid age
    Given a user provides invalid details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | Doe     |
        | Age              | -25     |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Age must be greater than 3" should be displayed

Scenario: Fail to create a user profile with invalid first name
    Given a user provides invalid details:
        | Field            | Value   |
        | FirstName        | 1       |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "FirstName must contain only alphabetic characters" should be displayed

Scenario: Fail to create a user profile with invalid last name
    Given a user provides invalid details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | 2       |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "LastName must contain only alphabetic characters" should be displayed

Scenario: Fail to create a user profile with invalid gender
    Given a user provides invalid details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | -20     |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Gender must be one of the predefined values" should be displayed

Scenario: Fail to create a user profile with invalid native language ID
    Given a user provides invalid details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | -31       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Native language ID must be greater than 0" should be displayed

Scenario: Fail to create a user profile with invalid country of origin
    Given a user provides invalid details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | -81       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Country of origin ID must be greater than 0" should be displayed

Scenario: Fail to create a user profile with invalid current country
    Given a user provides invalid details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | -91       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Current country ID must be greater than 0" should be displayed

Scenario: Fail to create a user profile with invalid hobbies
    Given a user provides invalid details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, -4    |
        | Interests        | 1, 2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Each hobby ID must be greater than 0" should be displayed

Scenario: Fail to create a user profile with invalid interests
    Given a user provides invalid details:
        | Field            | Value   |
        | FirstName        | John    |
        | LastName         | Doe     |
        | Age              | 25      |
        | Gender           | 0       |
        | NativeLanguageId | 1       |
        | CountryOfOrigin  | 1       |
        | CurrentCountry   | 1       |
        | Hobbies          | 2, 4    |
        | Interests        | 1, -2, 5 |
    When the user profile creation is attempted
    Then the profile creation should fail
    And an error message "Each interest ID must be greater than 0" should be displayed
