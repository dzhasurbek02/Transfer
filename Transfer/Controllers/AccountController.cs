using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.Account;
using Transfer.Features.Account.CreateAccount;

namespace Transfer.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;
    private readonly IValidator<CreateAccountRequest> _validatorCreate;

    public AccountController(IAccountService service, IValidator<CreateAccountRequest> validatorCreate)
    {
        _service = service;
        _validatorCreate = validatorCreate;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateAccount([FromBody] CreateAccountRequest request)
    {
        var result = await _validatorCreate.ValidateAsync(request);

        if (result.IsValid)
        {
            await _service.CreateAccount(request);

            return Ok("Account successfully created!");
        }

        return BadRequest(result.Errors.Select(e => e.ErrorMessage));
    }
}