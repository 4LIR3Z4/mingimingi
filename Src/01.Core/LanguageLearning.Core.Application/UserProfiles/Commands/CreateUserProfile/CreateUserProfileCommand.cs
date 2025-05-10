using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile.DTO;

namespace LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile;

public record CreateUserProfileCommand(CreateProfileRequest request) : ICommand<CreateProfileResponse>;
