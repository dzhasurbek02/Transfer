namespace Transfer.Features.ExchangeRate.UpdateExchangeRate;

public class UpdateExchangeRateRequest
{
    public Guid Id { get; set; }
    
    public Guid Currency1Id { get; set; }
    
    public Guid Currency2Id { get; set; }
    
    public float Rate { get; set; }
}