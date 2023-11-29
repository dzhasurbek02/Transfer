namespace Transfer.Entities;

public class Transactions : BaseEntity
{
    public Guid SenderId { get; set; }
    
    public Guid RecipientId { get; set; }
    
    public float Sum { get; set; }
    
    public DateTime TransactionDate { get; set; }
}