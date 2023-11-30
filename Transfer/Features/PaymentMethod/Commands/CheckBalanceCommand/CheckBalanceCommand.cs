using MediatR;

namespace Transfer.Features.PaymentMethod.Commands.CheckBalanceCommand;

public class CheckBalanceCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    
    public float Sum { get; set; }
}