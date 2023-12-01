using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.PaymentMethod.Commands.CreatePaymentMethod;

namespace Transfer.Controllers;

[Route("api/paymentMethods")]
[ApiController]
public class PaymentMethodController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentMethodController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreatePaymentMethod([FromBody] CreatePaymentMethodCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}