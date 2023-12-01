using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.Transaction.Command.CreateTransaction;

namespace Transfer.Controllers;

[Route("api/transactions")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateTransaction([FromBody] CreateTransactionCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}