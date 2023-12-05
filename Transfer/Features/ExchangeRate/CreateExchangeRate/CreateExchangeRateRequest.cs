namespace Transfer.Features.ExchangeRate.CreateExchangeRate;

public class CreateExchangeRateRequest
{
    public Guid Currency1Id { get; set; }
    
    public Guid Currency2Id { get; set; }
    
    public float Rate { get; set; }
}