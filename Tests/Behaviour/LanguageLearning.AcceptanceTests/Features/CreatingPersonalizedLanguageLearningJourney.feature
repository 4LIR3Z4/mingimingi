Feature: Creating a Personalized Language Learning Journey
As a language learner
I want to create a personalized learning journey for my target language
So that I can systematically improve my language skills with AI-generated learning paths

Scenario: Creating a learning journey with personalized learning path
Given I am logged into the language learning application
When I select "Spanish" as my target language
And I choose "Business" as my learning target
And I create learning goals for each skill type:
  | Skill Type | Practice Minutes Per Day | Description                                   |
  | Reading    | 20                       | Want to read business reports and contracts   |
  | Writing    | 15                       | Need to write professional emails             |
  | Listening  | 30                       | Understand business meetings and calls        |
  | Speaking   | 25                       | Present and negotiate in Spanish              |
  | Grammar    | 10                       | Master formal grammar structures              |
  | Vocabulary | 15                       | Focus on business and technical terms         |
And I provide my initial proficiency assessment:
  | Skill Type | Proficiency Level |
  | Reading    | A2                |
  | Writing    | A1                |
  | Listening  | A2                |
  | Speaking   | A1                |
  | Grammar    | A1                |
  | Vocabulary | A2                |
And I submit my learning journey request
Then the system should create a new Learning Journey
And the system should generate a personalized Learning Path
And the Learning Path should contain at least one Learning Sessions
And each Learning Session should have at least one Learning Content
And each Learning Session should have at least one Assessment Item
And I should be notified that my Learning Journey has been created successfully

Scenario: Progressing through learning sessions in a path
Given I have an active Learning Journey for "Spanish"
And my Learning Path has multiple Learning Sessions
When I complete all content and assessments in the current Learning Session
Then the system should mark the session as "Completed"
And I should be able to proceed to the next Learning Session in the path
And my progress should be tracked and visible

Scenario: Skipping a learning session
Given I have an active Learning Journey for "Spanish"
And my Learning Path has multiple Learning Sessions
When I choose to skip the current Learning Session
Then the system should allow me to access the next Learning Session
And the skipped session should be marked accordingly
And I should be informed that skipping may affect my overall learning progress

Scenario: Completing a learning path
Given I have an active Learning Journey for "Spanish"
And I have completed or skipped all Learning Sessions in my current path
When I finish the final session in the path
Then the system should mark the Learning Path as "Completed"
And I should be presented with an option to generate a new Learning Path
And my proficiency levels should be reassessed

Scenario: Abandoning a learning path
Given I have an active Learning Journey for Spanish
When I choose to abandon my current Learning Path
Then the system should mark the path as "Abandoned"
And I should be offered options to:
  | Option                    | Description                                   |
  | Generate new path         | Create a fresh Learning Path                  |
  | Adjust learning goals     | Modify my goals before creating a new path    |
  | Update proficiency levels | Reassess my current language skills           |

Scenario: Updating learning goals and generating a new path
Given I have an existing Learning Journey for Spanish
When I update my learning goals:
  | Skill Type | New Practice Minutes | New Description                          |
  | Speaking   | 40                   | Focus on business presentation skills     |
  | Vocabulary | 25                   | Expand industry-specific terminology      |
And I request a new Learning Path
Then the system should generate a new path based on my updated goals
And my Learning Journey should maintain my proficiency history
And the new path should reflect my adjusted priorities