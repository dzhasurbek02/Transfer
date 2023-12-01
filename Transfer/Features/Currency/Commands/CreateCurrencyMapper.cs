using AutoMapper;

namespace Transfer.Features.Currency.Commands;

public class CreateCurrencyMapper : Profile
{
    public CreateCurrencyMapper()
    {
        CreateMap<CreateCurrencyCommand, Entities.Currency>();
    }
}