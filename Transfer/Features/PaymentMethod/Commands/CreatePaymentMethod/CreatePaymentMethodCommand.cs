using MediatR;

namespace Transfer.Features.PaymentMethod.Commands.CreatePaymentMethod;

public class CreatePaymentMethodCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    
    public string Type { get; set; }
    
    public float Balance { get; set; }
}