using Transfer.Features.ExchangeRate.CreateExchangeRate;
using Transfer.Features.ExchangeRate.GetAllExchangeRates;
using Transfer.Features.ExchangeRate.UpdateExchangeRate;

namespace Transfer.Features.ExchangeRate;

public interface IExchangeRateService
{
    public Task CreateExchangeRate(CreateExchangeRateRequest request);

    public Task UpdateExchangeRate(UpdateExchangeRateRequest request);

    public Task<List<GetExchangeRatesResponse>> GetAllExchangeRates();
}