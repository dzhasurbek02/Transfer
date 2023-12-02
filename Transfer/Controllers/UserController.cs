using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.User;
using Transfer.Features.User.CreateUser;

namespace Transfer.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly IValidator<CreateUserRequest> _validatorCreate;

    public UserController(IUserService service, IValidator<CreateUserRequest> validatorCreate)
    {
        _service = service;
        _validatorCreate = validatorCreate;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var result = await _validatorCreate.ValidateAsync(request);

        if (result.IsValid)
        {
            await _service.CreateUser(request);

            return Ok("User successfully created!");
        }

        return BadRequest(result.Errors.Select(e => e.ErrorMessage));
    }
}