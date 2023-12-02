namespace Transfer.Features.Transaction.Requests;

public class CreateTransactionRequest
{
    public Guid SenderId { get; set; }

    public Guid RecipientId { get; set; }
   
    public float Sum { get; set; }
}