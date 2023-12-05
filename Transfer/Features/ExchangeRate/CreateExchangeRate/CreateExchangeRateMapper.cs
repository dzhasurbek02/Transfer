using AutoMapper;

namespace Transfer.Features.ExchangeRate.CreateExchangeRate;

public class CreateExchangeRateMapper : Profile
{
    public CreateExchangeRateMapper()
    {
        CreateMap<CreateExchangeRateRequest, Entities.ExchangeRate>();
    }
}