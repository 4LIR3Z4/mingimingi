using LanguageLearning.Core.Domain.UserProfiles.Entities;

namespace LanguageLearning.Core.Application.UserProfiles.Commands.DTO;
public record CreateProfileResponse(int ProfileId);
public static class CreateProfileResponseExtensions
{
    public static CreateProfileResponse ToCreateProfileResponseDto(this UserProfile userProfile)
    {
        throw new NotImplementedException();
    }
}
