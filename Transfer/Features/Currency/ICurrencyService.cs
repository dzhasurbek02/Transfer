using Transfer.Features.Currency.CreateCurrency;

namespace Transfer.Features.Currency;

public interface ICurrencyService
{
    public Task CreateCurrency(CreateCurrencyRequest request);
}