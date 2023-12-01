using MediatR;

namespace Transfer.Features.Account.Commands.CreateAccount;

public class CreateAccountCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    
    public string Type { get; set; }
    
    public float Balance { get; set; }
}