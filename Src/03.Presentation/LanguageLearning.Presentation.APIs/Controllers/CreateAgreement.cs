using LanguageLearning.Core.Application.Agreements.Commands;
using LanguageLearning.Core.Application.Common.Abstractions;
using LanguageLearning.Core.Domain.DTOs.AgreementDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace LanguageLearning.Core.Application.Agreements.Endpoints;
//public class Create : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//        app.MapPost("/Agreement",
//            [OutputCache] async ([FromBody] AgreementCreateRequest agreementCreateDto, CancellationToken cancellationToken, IMediatorService _mediator, HttpContext context) =>
//            {
//                var result = await _mediator.Send(new CreateAgreementCommand(agreementCreateDto), cancellationToken);
//                return result.Match(
//                    success => Results.Ok(result.Value),
//                    failed => Results.Problem(detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest)
//                );
//            })
//            .Produces<AgreementResponse>(StatusCodes.Status201Created)
//            .ProducesProblem(StatusCodes.Status400BadRequest)
//            .ProducesValidationProblem(422)
//            .WithDescription("CreateAgreement")
//            .Accepts<AgreementCreateRequest>(MediaTypeNames.Application.Json)
//            .WithTags("Agreement")
//            .WithName("CreateAgreement")
//            .IncludeInOpenApi();
//    }

//}