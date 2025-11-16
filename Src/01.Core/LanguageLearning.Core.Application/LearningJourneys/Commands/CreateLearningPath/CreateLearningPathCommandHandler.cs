using LanguageLearning.Core.Application.Common.Abstractions.AI.LLM.LearningPathGenerator;
using LanguageLearning.Core.Application.Common.Abstractions.Caching;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningPath.DTO;
using LanguageLearning.Core.Domain.LearningJourneys.Entities;

namespace LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningPath;
public sealed class CreateLearningPathCommandHandler(ILearningPathGenerator learningPathGenerator, IDbContext context, IReferenceDataCache referenceDataCache, TimeProvider timeProvider) :
    ICommandHandler<CreateLearningPathCommand, CreateLearningPathResponse>
{
    public async Task<Result<CreateLearningPathResponse>> Handle(CreateLearningPathCommand command, CancellationToken cancellationToken)
    {

        var journey = context.LearningJourneys.Find(command.Message.JourneyId);
        if (journey is not null)
        {
            var userProfile = context.UserProfiles.Find(journey.UserId);
            var language = (await referenceDataCache.GetLanguagesAsync(cancellationToken)).First(q => q.Id == journey.LanguageId);
            if (userProfile is not null && language is not null)
            {
                UserLearningProfile userLearningProfile = BuildUserLearningProfileFromJourney(journey, userProfile, language);
                var totalSessions = await learningPathGenerator.CalculateTotalSessionsAsync(userLearningProfile, cancellationToken);
                LearningPath learningPath = LearningPath.Create(timeProvider.GetUtcNow(), totalSessions);

                for (int i = 0; i < totalSessions; i++)
                {
                    var sessionContent = await learningPathGenerator.GenerateSessionContentAsync(userLearningProfile, cancellationToken);
                    var learningSession = LearningSession.Create(timeProvider.GetUtcNow());
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


                    var sessionAssessment = await learningPathGenerator.GenerateSessionAssessmentAsync(userLearningProfile, cancellationToken);
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
                await context.SaveChangesAsync(cancellationToken);

            }
        }
        return Result.Success<CreateLearningPathResponse>(new CreateLearningPathResponse() { });
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
}
