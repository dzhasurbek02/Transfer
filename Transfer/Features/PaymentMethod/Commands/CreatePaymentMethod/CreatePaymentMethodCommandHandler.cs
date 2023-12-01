using AutoMapper;
using MediatR;
using Transfer.Context;

namespace Transfer.Features.PaymentMethod.Commands.CreatePaymentMethod;

public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreatePaymentMethodCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var pm = _mapper.Map<Entities.Account>(request);

        _context.PaymentMethods.Add(pm);
        await _context.SaveChangesAsync(cancellationToken);

        return pm.Id;
    }
}