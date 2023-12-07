namespace Transfer.Features.ExchangeRate.GetExchangeRate;

public class GetExchangeRateRequest
{
    public Guid SenderCurrencyId { get; set; }
    
    public Guid RecipientCurrencyId { get; set; }
}