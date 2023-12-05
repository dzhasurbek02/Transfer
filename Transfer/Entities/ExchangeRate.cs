namespace Transfer.Entities;

public class ExchangeRate : BaseEntity
{
    public Guid Currency1Id { get; set; }
    public Currency CurrencySender { get; set; }
    
    public Guid Currency2Id { get; set; }
    public Currency CurrencyRecipient { get; set; }
    
    public float Rate { get; set; }
}