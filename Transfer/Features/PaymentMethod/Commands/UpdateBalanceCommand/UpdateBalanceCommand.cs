using MediatR;

namespace Transfer.Features.PaymentMethod.Commands.UpdateBalanceCommand;

public class UpdateBalanceCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    
    public float Sum { get; set; }
}