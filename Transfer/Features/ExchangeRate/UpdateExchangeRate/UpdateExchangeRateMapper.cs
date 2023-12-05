using AutoMapper;

namespace Transfer.Features.ExchangeRate.UpdateExchangeRate;

public class UpdateExchangeRateMapper : Profile
{
    public UpdateExchangeRateMapper()
    {
        CreateMap<UpdateExchangeRateRequest, Entities.ExchangeRate>();
    }
}