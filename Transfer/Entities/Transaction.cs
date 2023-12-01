namespace Transfer.Entities;

public class Transaction : BaseEntity
{
    public Guid SenderId { get; set; }
    public Account Sender { get; set; }

    public Guid RecipientId { get; set; }
    public Account Recipient { get; set; }
    
    public float Sum { get; set; }
    
    public DateTimeOffset TransactionDate = DateTimeOffset.Now.UtcDateTime;
}