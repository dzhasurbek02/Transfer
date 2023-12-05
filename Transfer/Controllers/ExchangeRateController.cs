using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.ExchangeRate;
using Transfer.Features.ExchangeRate.CreateExchangeRate;
using Transfer.Features.ExchangeRate.UpdateExchangeRate;

namespace Transfer.Controllers;

[Route("api/exchangeRates")]
[ApiController]
public class ExchangeRateController : ControllerBase
{
    private readonly IExchangeRateService _service;
    private readonly IValidator<CreateExchangeRateRequest> _validatorCreate;
    private readonly IValidator<UpdateExchangeRateRequest> _validatorUpdate;

    public ExchangeRateController(IExchangeRateService service,
        IValidator<CreateExchangeRateRequest> validatorCreate,
        IValidator<UpdateExchangeRateRequest> validatorUpdate)
    {
        _service = service;
        _validatorCreate = validatorCreate;
        _validatorUpdate = validatorUpdate;
    }
    
    [HttpGet(Name = "exchangeRateList")]
    public async Task<IActionResult> GetAll()
    {
        var rates = await _service.GetAllExchangeRates();

        return Ok(rates);
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateExchangeRateRequest request)
    {
       var result = await _validatorCreate.ValidateAsync(request);

        if (result.IsValid)
        {
            await _service.CreateExchangeRate(request);

            return Ok("ExchangeRate successfully created!");
        }

        return BadRequest(result.Errors.Select(t => t.ErrorMessage));
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateExchangeRateRequest request)
    {
        var result = await _validatorUpdate.ValidateAsync(request);

        if (result.IsValid)
        {
            await _service.UpdateExchangeRate(request);

            return Ok("ExchangeRate successfully updated!");
        }

        return BadRequest(result.Errors.Select(t => t.ErrorMessage));
    }
}