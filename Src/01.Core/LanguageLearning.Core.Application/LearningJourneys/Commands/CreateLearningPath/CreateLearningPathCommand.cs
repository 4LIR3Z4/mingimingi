using LanguageLearning.Core.Application.Common.Abstractions.Messaging.Dto;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningPath.DTO;

namespace LanguageLearning.Core.Application.LearningJourneys.Commands.CreateLearningPath;
public record CreateLearningPathCommand(JourneyMessage Message) : ICommand<CreateLearningPathResponse>;
