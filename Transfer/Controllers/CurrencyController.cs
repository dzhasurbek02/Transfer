using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.Currency.Commands;

namespace Transfer.Controllers;

[Route("api/paymentMethods")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CurrencyController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateCurrency([FromBody] CreateCurrencyCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}