using AutoMapper;
using MediatR;
using Transfer.Context;

namespace Transfer.Features.Account.Commands.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateAccountCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var pm = _mapper.Map<Entities.Account>(request);

        _context.Accounts.Add(pm);
        await _context.SaveChangesAsync(cancellationToken);

        return pm.Id;
    }
}