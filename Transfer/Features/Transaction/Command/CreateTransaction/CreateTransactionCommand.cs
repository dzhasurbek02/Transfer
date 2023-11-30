using MediatR;

namespace Transfer.Features.Transaction.Command.CreateTransaction;

public class CreateTransactionCommand : IRequest<bool>
{
    public Guid SenderId { get; set; }

    public Guid RecipientId { get; set; }
   
    public float Sum { get; set; }
}