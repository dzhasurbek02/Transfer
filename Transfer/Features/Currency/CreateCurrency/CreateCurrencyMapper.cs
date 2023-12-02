using AutoMapper;

namespace Transfer.Features.Currency.CreateCurrency;

public class CreateCurrencyMapper : Profile
{
    public CreateCurrencyMapper()
    {
        CreateMap<CreateCurrencyRequest, Entities.Currency>();
    }
}