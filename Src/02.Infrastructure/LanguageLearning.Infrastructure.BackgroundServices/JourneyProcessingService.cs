using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Common.Abstractions.AI.LearningPathGenerator;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.Common.Abstractions.Messaging;
using LanguageLearning.Core.Domain.LearningJourneys.Entities;
using Microsoft.Extensions.Hosting;

namespace LanguageLearning.Infrastructure.BackgroundServices;
internal class JourneyProcessingService : IHostedService
{
    private readonly IMessageBroker _messageBroker;
    private readonly ILearningPathGenerator _learningPathGenerator;
    private readonly IDbContext _context;
    private readonly IReferenceDataCache _referenceDataCache;
    private readonly TimeProvider _timeProvider;
    public JourneyProcessingService(IMessageBroker messageBroker, ILearningPathGenerator learningPathGenerator, IDbContext context, IReferenceDataCache referenceDataCache, TimeProvider timeProvider)
    {
        _messageBroker = messageBroker;
        _learningPathGenerator = learningPathGenerator;
        _context = context;
        _referenceDataCache = referenceDataCache;
        _timeProvider = timeProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _messageBroker.SubscribeToQueueAsync<JourneyMessage>(
            "journey.created",
            async message =>
            {
                var journey = _context.LearningJourneys.Find(message.JourneyId);
                if (journey is not null)
                {
                    var userProfile = _context.UserProfiles.Find(journey.UserId);
                    var language = (await _referenceDataCache.GetLanguagesAsync(cancellationToken)).First(q => q.Id == journey.LanguageId);
                    if (userProfile is not null)
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
                        var totalSessions = await _learningPathGenerator.CalculateTotalSessionsAsync(userLearningProfile, cancellationToken);
                        LearningPath learningPath = LearningPath.Create(_timeProvider.GetUtcNow(), totalSessions);

                        for (int i = 0; i < totalSessions; i++)
                        {
                            var sessionContent = await _learningPathGenerator.GenerateSessionContentAsync(userLearningProfile, cancellationToken);
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


                            var sessionAssessment = await _learningPathGenerator.GenerateSessionAssessmentAsync(userLearningProfile, cancellationToken);
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
                        await _context.SaveChangesAsync(cancellationToken);

                    }
                }
            });
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
