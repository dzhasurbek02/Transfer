namespace Transfer.Features.ExchangeRate.GetAllExchangeRates;

public class GetExchangeRatesResponse
{
    public string Currency1Name { get; set; }
    
    public string Currency2Name { get; set; }
    
    public float Rate { get; set; }
}