using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace LanguageLearning.Presentation.API.Framework;
[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized, "application/problem+json")]
[ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
[Produces(MediaTypeNames.Application.Json)]
//[Authorize]
public class BaseController : ControllerBase
{
}
