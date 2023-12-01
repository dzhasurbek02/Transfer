using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.User.Commands.CreateUser;

namespace Transfer.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}