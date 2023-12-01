using AutoMapper;
using MediatR;
using Transfer.Context;

namespace Transfer.Features.Currency.Commands;

public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateCurrencyCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        var currency = _mapper.Map<Entities.Currency>(request);

        _context.Currencies.Add(currency);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}