using AutoMapper;
using MediatR;
using Transfer.Context;

namespace Transfer.Features.PaymentMethod.Commands.CreatePaymentMethod;

public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, Guid>
{
    private readonly IApplicationDBContext _context;
    private readonly IMapper _mapper;

    public CreatePaymentMethodCommandHandler(IApplicationDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var pm = _mapper.Map<Entities.PaymentMethod>(request);

        _context.PaymentMethods.Add(pm);
        await _context.SaveChangesAsync(cancellationToken);

        return pm.Id;
    }
}