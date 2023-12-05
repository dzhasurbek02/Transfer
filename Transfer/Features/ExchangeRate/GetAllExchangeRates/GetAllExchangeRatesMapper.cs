using AutoMapper;

namespace Transfer.Features.ExchangeRate.GetAllExchangeRates;

public class GetAllExchangeRatesMapper : Profile
{
    public GetAllExchangeRatesMapper()
    {
        CreateMap<Entities.ExchangeRate, GetExchangeRatesResponse>()
            .ForMember(r => r.Currency1Name,
                t => t.MapFrom(src => $"{src.CurrencySender.Type}"))
            .ForMember(r => r.Currency2Name,
                t => t.MapFrom(src => $"{src.CurrencyRecipient.Type}"));
    }
}