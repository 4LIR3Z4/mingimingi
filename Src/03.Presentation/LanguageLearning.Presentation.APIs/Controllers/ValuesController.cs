using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile;
using LanguageLearning.Core.Application.UserProfiles.Commands.CreateUserProfile.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearning.Presentation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public ValuesController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpGet]
    public async Task<ActionResult<string>> GetUserProfiles()
    {
        var result = await
            _commandDispatcher.Dispatch<CreateUserProfileCommand, CreateProfileResponse>
            (new CreateUserProfileCommand(
            new CreateProfileRequest()
            {
                Age = 25,
            }));

        return "Ok(result)";
    }
}
