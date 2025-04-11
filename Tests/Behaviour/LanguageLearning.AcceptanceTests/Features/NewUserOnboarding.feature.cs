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
    public partial class NewUserOnboardingFeature : object, Xunit.IClassFixture<NewUserOnboardingFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "NewUserOnboarding", "  As a new user\r\n  I want to create a user profile\r\n  So that I can start using t" +
                "he language learning platform", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "NewUserOnboarding.feature"
#line hidden
        
        public NewUserOnboardingFeature(NewUserOnboardingFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Successfully create a user profile")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Successfully create a user profile")]
        public async System.Threading.Tasks.Task SuccessfullyCreateAUserProfile()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Successfully create a user profile", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table1.AddRow(new string[] {
                            "FirstName",
                            "John"});
                table1.AddRow(new string[] {
                            "LastName",
                            "Doe"});
                table1.AddRow(new string[] {
                            "Age",
                            "25"});
                table1.AddRow(new string[] {
                            "Gender",
                            "0"});
                table1.AddRow(new string[] {
                            "NativeLanguageId",
                            "1"});
                table1.AddRow(new string[] {
                            "CountryOfOrigin",
                            "1"});
                table1.AddRow(new string[] {
                            "CurrentCountry",
                            "1"});
                table1.AddRow(new string[] {
                            "Hobbies",
                            "2, 4"});
                table1.AddRow(new string[] {
                            "Interests",
                            "1, 2, 5"});
#line 7
    await testRunner.GivenAsync("a user provides valid details:", ((string)(null)), table1, "Given ");
#line hidden
#line 18
    await testRunner.WhenAsync("the user profile is created", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 19
    await testRunner.ThenAsync("the profile should be saved successfully", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with missing required fields")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with missing required fields")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithMissingRequiredFields()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with missing required fields", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table2 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table2.AddRow(new string[] {
                            "FirstName",
                            ""});
                table2.AddRow(new string[] {
                            "LastName",
                            ""});
                table2.AddRow(new string[] {
                            "Age",
                            ""});
                table2.AddRow(new string[] {
                            "Gender",
                            ""});
                table2.AddRow(new string[] {
                            "NativeLanguageId",
                            ""});
                table2.AddRow(new string[] {
                            "CountryOfOrigin",
                            ""});
                table2.AddRow(new string[] {
                            "CurrentCountry",
                            ""});
#line 22
    await testRunner.GivenAsync("a user provides incomplete details:", ((string)(null)), table2, "Given ");
#line hidden
#line 31
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 32
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 33
    await testRunner.AndAsync("an error message \"All fields are required\" should be displayed", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with invalid age")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with invalid age")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithInvalidAge()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with invalid age", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 35
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table3 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table3.AddRow(new string[] {
                            "Age",
                            "-5"});
#line 36
    await testRunner.GivenAsync("a user provides invalid details:", ((string)(null)), table3, "Given ");
#line hidden
#line 39
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 40
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 41
    await testRunner.AndAsync("an error message \"Age must be a positive integer\" should be displayed", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with invalid first name")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with invalid first name")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithInvalidFirstName()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with invalid first name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 43
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table4 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table4.AddRow(new string[] {
                            "FirstName",
                            "12345"});
#line 44
    await testRunner.GivenAsync("a user provides invalid details:", ((string)(null)), table4, "Given ");
#line hidden
#line 47
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 48
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 49
    await testRunner.AndAsync("an error message \"FirstName must be a valid string\" should be displayed", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with invalid last name")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with invalid last name")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithInvalidLastName()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with invalid last name", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 51
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table5 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table5.AddRow(new string[] {
                            "LastName",
                            "67890"});
#line 52
    await testRunner.GivenAsync("a user provides invalid details:", ((string)(null)), table5, "Given ");
#line hidden
#line 55
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 56
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 57
    await testRunner.AndAsync("an error message \"LastName must be a valid string\" should be displayed", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with invalid gender")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with invalid gender")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithInvalidGender()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with invalid gender", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 59
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table6 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table6.AddRow(new string[] {
                            "Gender",
                            "Alien"});
#line 60
    await testRunner.GivenAsync("a user provides invalid details:", ((string)(null)), table6, "Given ");
#line hidden
#line 63
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 64
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 65
    await testRunner.AndAsync("an error message \"Gender must be one of the predefined values\" should be displaye" +
                        "d", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with invalid native language ID")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with invalid native language ID")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithInvalidNativeLanguageID()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with invalid native language ID", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 67
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table7 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table7.AddRow(new string[] {
                            "NativeLanguageId",
                            "-1"});
#line 68
    await testRunner.GivenAsync("a user provides invalid details:", ((string)(null)), table7, "Given ");
#line hidden
#line 71
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 72
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 73
    await testRunner.AndAsync("an error message \"NativeLanguageId must be a positive integer\" should be displaye" +
                        "d", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with invalid country of origin")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with invalid country of origin")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithInvalidCountryOfOrigin()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with invalid country of origin", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 75
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table8 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table8.AddRow(new string[] {
                            "CountryOfOrigin",
                            "XYZ"});
#line 76
    await testRunner.GivenAsync("a user provides invalid details:", ((string)(null)), table8, "Given ");
#line hidden
#line 79
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 80
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 81
    await testRunner.AndAsync("an error message \"CountryOfOrigin must be a valid country\" should be displayed", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with invalid current country")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with invalid current country")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithInvalidCurrentCountry()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with invalid current country", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 83
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table9 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table9.AddRow(new string[] {
                            "CurrentCountry",
                            "ABC"});
#line 84
    await testRunner.GivenAsync("a user provides invalid details:", ((string)(null)), table9, "Given ");
#line hidden
#line 87
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 88
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 89
    await testRunner.AndAsync("an error message \"CurrentCountry must be a valid country\" should be displayed", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with invalid hobbies")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with invalid hobbies")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithInvalidHobbies()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with invalid hobbies", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                global::Reqnroll.Table table10 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table10.AddRow(new string[] {
                            "Hobbies",
                            "123, Invalid"});
#line 92
    await testRunner.GivenAsync("a user provides invalid details:", ((string)(null)), table10, "Given ");
#line hidden
#line 95
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 96
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 97
    await testRunner.AndAsync("an error message \"Hobbies must be a list of valid hobby names\" should be displaye" +
                        "d", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Fail to create a user profile with invalid interests")]
        [Xunit.TraitAttribute("FeatureTitle", "NewUserOnboarding")]
        [Xunit.TraitAttribute("Description", "Fail to create a user profile with invalid interests")]
        public async System.Threading.Tasks.Task FailToCreateAUserProfileWithInvalidInterests()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Fail to create a user profile with invalid interests", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 99
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table11 = new global::Reqnroll.Table(new string[] {
                            "Field",
                            "Value"});
                table11.AddRow(new string[] {
                            "Interests",
                            "456, Invalid"});
#line 100
    await testRunner.GivenAsync("a user provides invalid details:", ((string)(null)), table11, "Given ");
#line hidden
#line 103
    await testRunner.WhenAsync("the user profile creation is attempted", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 104
    await testRunner.ThenAsync("the profile creation should fail", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 105
    await testRunner.AndAsync("an error message \"Interests must be a list of valid interest names\" should be dis" +
                        "played", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
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
                await NewUserOnboardingFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await NewUserOnboardingFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
