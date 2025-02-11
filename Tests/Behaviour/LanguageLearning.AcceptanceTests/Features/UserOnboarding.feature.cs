﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LanguageLearning.AcceptanceTests.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class UserOnboardingFeature : object, Xunit.IClassFixture<UserOnboardingFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "User Onboarding", "  As a prospective language learner\r\n  I want to sign up using my existing SSO ac" +
                "count and complete my profile with detailed personal information\r\n  So that I ca" +
                "n receive a tailored language learning experience", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "UserOnboarding.feature"
#line hidden
        
        public UserOnboardingFeature(UserOnboardingFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Successful onboarding with complete profile details via SSO")]
        [Xunit.TraitAttribute("FeatureTitle", "User Onboarding")]
        [Xunit.TraitAttribute("Description", "Successful onboarding with complete profile details via SSO")]
        public async System.Threading.Tasks.Task SuccessfulOnboardingWithCompleteProfileDetailsViaSSO()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Successful onboarding with complete profile details via SSO", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 11
    await testRunner.GivenAsync("a valid SSO token is provided", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table1.AddRow(new string[] {
                            "FirstName",
                            "Alice"});
                table1.AddRow(new string[] {
                            "LastName",
                            "Johnson"});
                table1.AddRow(new string[] {
                            "Age",
                            "25"});
                table1.AddRow(new string[] {
                            "Gender",
                            "Female"});
                table1.AddRow(new string[] {
                            "NativeLanguage",
                            "English"});
                table1.AddRow(new string[] {
                            "Hobbies",
                            "Reading, Cycling"});
                table1.AddRow(new string[] {
                            "LearningGoals",
                            "Achieve fluency"});
                table1.AddRow(new string[] {
                            "SkillProficiency",
                            "Intermediate"});
                table1.AddRow(new string[] {
                            "LearningPreferences",
                            "Visual, Evening"});
                table1.AddRow(new string[] {
                            "StudyTimePerWeek",
                            "8"});
                table1.AddRow(new string[] {
                            "ExamParticipation",
                            "Yes"});
                table1.AddRow(new string[] {
                            "CountryOfOrigin",
                            "USA"});
                table1.AddRow(new string[] {
                            "CurrentCountry",
                            "Canada"});
                table1.AddRow(new string[] {
                            "Interests",
                            "Travel, Culture"});
#line 12
    await testRunner.WhenAsync("I provide the following profile details:", ((string)(null)), table1, "When ");
#line hidden
#line 28
    await testRunner.ThenAsync("my profile should be created successfully", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Successful onboarding when optional fields (e.g., Hobbies and Interests) are omit" +
            "ted")]
        [Xunit.TraitAttribute("FeatureTitle", "User Onboarding")]
        [Xunit.TraitAttribute("Description", "Successful onboarding when optional fields (e.g., Hobbies and Interests) are omit" +
            "ted")]
        public async System.Threading.Tasks.Task SuccessfulOnboardingWhenOptionalFieldsE_G_HobbiesAndInterestsAreOmitted()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Successful onboarding when optional fields (e.g., Hobbies and Interests) are omit" +
                    "ted", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 32
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 33
    await testRunner.GivenAsync("a valid SSO token is provided", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
                global::Reqnroll.Table table2 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table2.AddRow(new string[] {
                            "FirstName",
                            "Bob"});
                table2.AddRow(new string[] {
                            "LastName",
                            "Smith"});
                table2.AddRow(new string[] {
                            "Age",
                            "30"});
                table2.AddRow(new string[] {
                            "Gender",
                            "Male"});
                table2.AddRow(new string[] {
                            "NativeLanguage",
                            "Spanish"});
                table2.AddRow(new string[] {
                            "Hobbies",
                            "Reading"});
                table2.AddRow(new string[] {
                            "LearningGoals",
                            "Casual learning"});
                table2.AddRow(new string[] {
                            "SkillProficiency",
                            "Beginner"});
                table2.AddRow(new string[] {
                            "LearningPreferences",
                            ""});
                table2.AddRow(new string[] {
                            "StudyTimePerWeek",
                            "5"});
                table2.AddRow(new string[] {
                            "ExamParticipation",
                            ""});
                table2.AddRow(new string[] {
                            "CountryOfOrigin",
                            ""});
                table2.AddRow(new string[] {
                            "CurrentCountry",
                            ""});
                table2.AddRow(new string[] {
                            "Interests",
                            ""});
#line 34
    await testRunner.WhenAsync("I provide the following profile details:", ((string)(null)), table2, "When ");
#line hidden
#line 50
    await testRunner.ThenAsync("my profile should be created successfully (using default values for omitted optio" +
                        "nal fields)", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Onboarding fails when required fields are missing")]
        [Xunit.TraitAttribute("FeatureTitle", "User Onboarding")]
        [Xunit.TraitAttribute("Description", "Onboarding fails when required fields are missing")]
        public async System.Threading.Tasks.Task OnboardingFailsWhenRequiredFieldsAreMissing()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Onboarding fails when required fields are missing", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 56
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 57
    await testRunner.GivenAsync("a valid SSO token is provided", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
                global::Reqnroll.Table table3 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table3.AddRow(new string[] {
                            "FirstName",
                            ""});
                table3.AddRow(new string[] {
                            "LastName",
                            ""});
                table3.AddRow(new string[] {
                            "Age",
                            ""});
                table3.AddRow(new string[] {
                            "Gender",
                            ""});
                table3.AddRow(new string[] {
                            "NativeLanguage",
                            ""});
                table3.AddRow(new string[] {
                            "Hobbies",
                            ""});
                table3.AddRow(new string[] {
                            "LearningGoals",
                            ""});
                table3.AddRow(new string[] {
                            "SkillProficiency",
                            ""});
                table3.AddRow(new string[] {
                            "LearningPreferences",
                            ""});
                table3.AddRow(new string[] {
                            "StudyTimePerWeek",
                            ""});
                table3.AddRow(new string[] {
                            "ExamParticipation",
                            ""});
                table3.AddRow(new string[] {
                            "CountryOfOrigin",
                            ""});
                table3.AddRow(new string[] {
                            "CurrentCountry",
                            ""});
                table3.AddRow(new string[] {
                            "Interests",
                            ""});
#line 58
    await testRunner.WhenAsync("I attempt to submit the profile details:", ((string)(null)), table3, "When ");
#line hidden
                global::Reqnroll.Table table4 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Error Message"});
                table4.AddRow(new string[] {
                            "FirstName",
                            "FirstName must be provided."});
                table4.AddRow(new string[] {
                            "LastName",
                            "LastName must be provided."});
                table4.AddRow(new string[] {
                            "Age",
                            "Age must be a positive integer."});
                table4.AddRow(new string[] {
                            "Gender",
                            "Gender must be specified as Male or Female."});
                table4.AddRow(new string[] {
                            "NativeLanguage",
                            "NativeLanguage must be provided."});
                table4.AddRow(new string[] {
                            "SkillProficiency",
                            "SkillProficiency must be provided."});
                table4.AddRow(new string[] {
                            "StudyTimePerWeek",
                            "StudyTimePerWeek must be a positive integer."});
                table4.AddRow(new string[] {
                            "Interests",
                            "At least one interest must be provided."});
                table4.AddRow(new string[] {
                            "Hobbies",
                            "At least one hobby must be provided."});
#line 74
    await testRunner.ThenAsync("I should see the following error messages:", ((string)(null)), table4, "Then ");
#line hidden
#line 85
    await testRunner.AndAsync("my profile should not be created", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Onboarding fails due to invalid SSO token")]
        [Xunit.TraitAttribute("FeatureTitle", "User Onboarding")]
        [Xunit.TraitAttribute("Description", "Onboarding fails due to invalid SSO token")]
        public async System.Threading.Tasks.Task OnboardingFailsDueToInvalidSSOToken()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Onboarding fails due to invalid SSO token", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 91
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 92
    await testRunner.GivenAsync("an invalid SSO token is provided", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 93
    await testRunner.ThenAsync("I should see an error message with 401 code", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 94
    await testRunner.AndAsync("my profile should not be created", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await UserOnboardingFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await UserOnboardingFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
