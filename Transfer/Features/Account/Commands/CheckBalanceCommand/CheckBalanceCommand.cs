using MediatR;

namespace Transfer.Features.Account.Commands.CheckBalanceCommand;

public class CheckBalanceCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    
    public float Sum { get; set; }
}