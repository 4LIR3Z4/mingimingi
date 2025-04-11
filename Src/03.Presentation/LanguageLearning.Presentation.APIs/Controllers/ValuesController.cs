using LanguageLearning.Core.Application.UserProfiles.Commands.DTO;
using LanguageLearning.Core.Application.UserProfiles.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;

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
