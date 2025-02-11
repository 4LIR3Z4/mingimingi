using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Application.Customers.Commands;
using LanguageLearning.Core.Application.Customers.Commands.Dto;
using LanguageLearning.Presentation.API.Framework;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearning.Presentation.API.Controllers.CustomerEndpoints;
public sealed class CustomerController : BaseController
{
    private readonly IMediatorService _mediator;
    public CustomerController(IMediatorService mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [ProducesResponseType<CustomerResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status422UnprocessableEntity, "application/problem+json")]
    [EndpointDescription("Create Customer")]
    [Tags("Customer")]
    public async Task<Results<Ok<CustomerResponse>, ProblemHttpResult>> CreateCustomer(CustomerCreateRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new CreateCustomerCommand(request),
            cancellationToken);

        return result.Match<Results<Ok<CustomerResponse>, ProblemHttpResult>>(
            success => TypedResults.Ok(success),
            failed => TypedResults.Problem(detail: failed.Description, statusCode: StatusCodes.Status400BadRequest)
        );
    }
}
