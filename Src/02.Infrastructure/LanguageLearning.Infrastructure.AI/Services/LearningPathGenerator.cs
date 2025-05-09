using LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Domain.Prompts.Entities;

namespace LanguageLearning.Infrastructure.AI.Services;
public sealed class LearningPathGenerator : ILearningPathGenerator
{
    private readonly IReferenceDataCache _referenceDataCache;

    public LearningPathGenerator(IReferenceDataCache referenceDataCache)
    {
        _referenceDataCache = referenceDataCache;
    }

    public async Task<int> CalculateTotalSessionsAsync(UserLearningProfile profile, CancellationToken cancellationToken = default)
    {
        
        var languageProficienciesFormatted = string.Join(" , ", profile.LanguageProficiencies.Select(q => $"{q.Key} = {q.Value}"));
        var promptParameters = new Dictionary<string, string>
        {
            { "__TargetLanguage__", profile.TargetLanguage },
            { "__PracticeTimePerDayInMinutes__", profile.PracticeTimePerDayInMinutes.ToString() },
            { "__CurrentCountry__", profile.CurrentCountry },
            { "__Interests__", string.Join(',', profile.Interests) },
            { "__Hobbies__", string.Join(',', profile.Hobbies) },
            { "__Age__", profile.Age.ToString() },
            { "__Gender__", profile.Gender },
            { "__CountryOfOrigin__", profile.CountryOfOrigin },
            { "__LearningTarget__", profile.LearningTarget },
            { "__LanguageProficiencies__", languageProficienciesFormatted }

        };

        //var allPrompts = await _referenceDataCache.GetPromptsAsync(cancellationToken);
        //var prompt = allPrompts.First(q => q.Name.Value == "CalculateTotalSessions");
        string template = @"You are an expert language‑learning curriculum designer.
Input:
{
""Age"": __Age__,
""Gender"": __Gender__,
""Country Of Origin"": ""__CountryOfOrigin__"",
""Current Country"": ""__CurrentCountry__"",
""Target Language"": ""__TargetLanguage__"",
""Hobbies"": [""__Hobbies__""],
""Interests"": [""__Interests__""],
""Learning Target"": ""__LearningTarget__"",
""Practice Time Per Day In Minutes"": __PracticeTimePerDayInMinutes__, 
""Language Proficiencies"": ""__LanguageProficiencies__""
}
Your task is to:

1. Analyze the user’s background (age, gender, origin/current country, hobbies, interests).
2. For each skill (e.g. reading, writing, listening, speaking):
   a. calculate how many minutes per day should user allocate to each skill based on the Practice Time Per Day In Minutes that user provided
   b. Estimate how many sessions (of that daily‑minutes length) are needed to go from current stage to the level implied by Learning Target (e.g. “General Training”, “Business”, “School”, ""Exam Preparation"", ""Immigration"", ""FLUENCY"", etc.). 
3. Factor in that different ages and cultural backgrounds affect learning pace (e.g. younger learners may require fewer sessions; adult heritage speakers may require fewer listening/speaking sessions).
4. be optimistic about the time needed to achieve the target and adjust the time by user‑specific modifiers derived from hobbies/interests (e.g. a user who enjoys reading may learn reading 10 % faster).
5. don't forget that skills have overlap. for instance when the user is reading a paragraph or listening to an audio file , they are learning new words and grammar in the process so it has a direct impact on time required for other skills.
6. in each session the user will work on all the skills.
7. after your calculations , review the time required for each skill and adjust them in a way that user can achieve the target in all skills at the same time.(for instance if writing skill requires 100 sessions and listening skill requires 50 sessions , adjust the practice per day so user can achieve both targets in 75 days)

Output : only a JSON (no text, no explanation) in this format : 
{
""total_sessions_required"":""100"",
""time_required_in_minutes_per_skill"":{""reading"":10 , ""writing"":20 , ""listening"":10 , ""speaking"" : 10}
}
";
        var prompt = Prompt.Create("test", "1.0.0", template, "test desc", promptParameters);
        var promptText = prompt.RenderTemplate(promptParameters);
        return await Task.FromResult(1);
    }

    public Task<SessionAssessment> GenerateSessionAssessmentAsync(UserLearningProfile profile, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<SessionContent> GenerateSessionContentAsync(UserLearningProfile profile, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
