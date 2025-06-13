using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.Common.Abstractions.Messaging;
using LanguageLearning.Core.Domain.LearningJourneys.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LanguageLearning.Infrastructure.BackgroundServices;
internal class JourneyProcessingService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    public JourneyProcessingService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    private static UserLearningProfile BuildUserLearningProfileFromJourney(LearningJourney journey, Core.Domain.UserProfiles.Entities.UserProfile userProfile, Core.Domain.Languages.Entities.Language language)
    {
        var lastProficiency = journey.ProficiencyHistory.Last();
        var proficiencyDict = new Dictionary<string, string>
                        {
                            { "reading", lastProficiency.ReadingProficiency.ToString() },
                            { "writing", lastProficiency.WritingProficiency.ToString() },
                            { "listening", lastProficiency.ListeningProficiency.ToString() },
                            { "speaking", lastProficiency.SpeakingProficiency.ToString() }
                        };
        var userLearningProfile = new UserLearningProfile()
        {
            Age = userProfile.Birthdate.GetAge(),
            CountryOfOrigin = userProfile.CountryOfOrigin.Name,
            CurrentCountry = userProfile.CountryOfOrigin.Name,
            Gender = nameof(userProfile.Gender),
            Hobbies = userProfile.UserHobbies.Select(q => q.Hobby.Name).ToList(),
            Interests = userProfile.UserInterests.Select(q => q.Interest.Name).ToList(),
            LanguageProficiencies = proficiencyDict,
            LearningTarget = nameof(journey.LearningTarget),
            PracticeTimePerDayInMinutes = journey.PracticePerDayInMinutes,
            TargetLanguage = language.Name
        };
        return userLearningProfile;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        using IServiceScope scope = _scopeFactory.CreateScope();
        var _messageBroker = scope.ServiceProvider.GetRequiredService<IMessageBroker>();
        var _learningPathGenerator = scope.ServiceProvider.GetRequiredService<ILearningPathGenerator>();
        var _context = scope.ServiceProvider.GetRequiredService<IDbContext>();
        var _referenceDataCache = scope.ServiceProvider.GetRequiredService<IReferenceDataCache>();
        var _timeProvider = scope.ServiceProvider.GetRequiredService<TimeProvider>();

        _messageBroker.SubscribeToQueueAsync<JourneyMessage>(
            QueueName.JourneyCreated,
            async message =>
            {
                var journey = _context.LearningJourneys.Find(message.JourneyId);
                if (journey is not null)
                {
                    var userProfile = _context.UserProfiles.Find(journey.UserId);
                    var language = (await _referenceDataCache.GetLanguagesAsync(stoppingToken)).First(q => q.Id == journey.LanguageId);
                    if (userProfile is not null)
                    {
                        UserLearningProfile userLearningProfile = BuildUserLearningProfileFromJourney(journey, userProfile, language);
                        var totalSessions = await _learningPathGenerator.CalculateTotalSessionsAsync(userLearningProfile, stoppingToken);
                        LearningPath learningPath = LearningPath.Create(_timeProvider.GetUtcNow(), totalSessions);

                        for (int i = 0; i < totalSessions; i++)
                        {
                            var sessionContent = await _learningPathGenerator.GenerateSessionContentAsync(userLearningProfile, stoppingToken);
                            var learningSession = LearningSession.Create(_timeProvider.GetUtcNow());
                            foreach (var content in sessionContent.Contents)
                            {
                                var learningContent = LearningContent.Create(
                                content.SkillType,
                                content.Title,
                                content.ContentData,
                                content.ContentMetadata,
                                content.ContentDifficulty,
                                content.TimeNeededToComplete,
                                content.ContentType
                                );
                                learningSession.AddContent(learningContent);
                            }


                            var sessionAssessment = await _learningPathGenerator.GenerateSessionAssessmentAsync(userLearningProfile, stoppingToken);
                            foreach (var assessment in sessionAssessment.Assessments)
                            {
                                var assessmentItem = AssessmentItem.Create(
                                    assessment.Question,
                                    assessment.CorrectAnswer,
                                    assessment.TargetedSkill,
                                    assessment.Difficulty
                                    );
                                learningSession.AddAssessment(assessmentItem);
                            }
                            learningPath.AddSession(learningSession);
                        }
                        journey.AddLearningPath(learningPath);
                        await _context.SaveChangesAsync(stoppingToken);

                    }
                }
            }, stoppingToken);
        return Task.CompletedTask;
    }
}
