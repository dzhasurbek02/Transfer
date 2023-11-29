namespace Transfer.Entities;

public class PaymentMethod : BaseEntity
{
    public Guid UserId { get; set; }
    
    public string Type { get; set; }
    
    public float Balance { get; set; }
}