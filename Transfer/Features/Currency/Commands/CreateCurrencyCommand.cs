using MediatR;

namespace Transfer.Features.Currency.Commands;

public class CreateCurrencyCommand : IRequest
{
    public string Type { get; set; }
}