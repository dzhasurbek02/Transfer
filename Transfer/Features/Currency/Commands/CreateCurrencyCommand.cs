using MediatR;

namespace Transfer.Features.Currency.Commands;

public class CreateCurrencyCommand : IRequest
{
    public Guid Type { get; set; }
}