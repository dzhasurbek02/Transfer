using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Transfer.Features.Transaction;
using Transfer.Features.Transaction.Requests;

namespace Transfer.Controllers;

[Route("api/transactions")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _service;
    private readonly IValidator<CreateTransactionRequest> _validatorCreate;

    public TransactionController(ITransactionService service, IValidator<CreateTransactionRequest> validatorCreate)
    {
        _service = service;
        _validatorCreate = validatorCreate;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateTransaction([FromBody] CreateTransactionRequest request)
    {
        var result = await _validatorCreate.ValidateAsync(request);

        if (result.IsValid)
        {
            await _service.CreateTransaction(request);

            return Ok("Transaction completed successfully!");
        }

        return BadRequest(result.Errors.Select(e => e.ErrorMessage));
    }
}