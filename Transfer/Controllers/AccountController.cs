using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.Account.Commands.CreateAccount;

namespace Transfer.Controllers;

[Route("api/currencies")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateAccount([FromBody] CreateAccountCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}