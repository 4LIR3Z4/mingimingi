using LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
using LanguageLearning.Infrastructure.AI.Services;

namespace LanguageLearning.Core.Tests;

public class Test1
{
    private readonly ILearningPathGenerator _learningPathGenerator;

    public Test1()
    {
        _learningPathGenerator = new LearningPathGenerator();
    }

    [Fact]
    public async Task TestMethod1()
    {
        var x = await _learningPathGenerator.CalculateTotalSessionsAsync(new UserLearningProfile()
        {
            Age=35,
            CountryOfOrigin="iran",
            CurrentCountry="canada",
            Gender="male",
            Hobbies= new List<string>() { "hiss", "byesss" },
            Interests=new List<string>() { "hi","bye"},
            LanguageProficiencies=new Dictionary<string, string>()
            {
                {"reading","A1"},
                {"writing","B2"},
                {"speaking","C1"},
                {"listening","C2"}
            },
            LearningTarget = "speak fluently",
            PracticeTimePerDayInMinutes = 30,
            TargetLanguage="French"
        });
    }
}
