using AutoMapper;

namespace Transfer.Features.PaymentMethod.Commands.CreatePaymentMethod;

public class CreatePaymentMethodMapper : Profile
{
    public CreatePaymentMethodMapper()
    {
        CreateMap<CreatePaymentMethodCommand, Entities.PaymentMethod>();
    }
}