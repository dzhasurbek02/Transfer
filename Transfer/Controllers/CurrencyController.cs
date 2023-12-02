using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.Currency;
using Transfer.Features.Currency.CreateCurrency;

namespace Transfer.Controllers;

[Route("api/currencies")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _service;
    private readonly IValidator<CreateCurrencyRequest> _validatorCreate;

    public CurrencyController(ICurrencyService service, IValidator<CreateCurrencyRequest> validatorCreate)
    {
        _service = service;
        _validatorCreate = validatorCreate;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateCurrency([FromBody] CreateCurrencyRequest request)
    {
        var result = await _validatorCreate.ValidateAsync(request);

        if (result.IsValid)
        {
            await _service.CreateCurrency(request);

            return Ok("Currency successfully created!");
        }

        return BadRequest(result.Errors.Select(e => e.ErrorMessage));
    }
}