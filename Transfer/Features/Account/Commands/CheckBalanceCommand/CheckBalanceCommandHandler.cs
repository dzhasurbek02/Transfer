using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transfer.Context;

namespace Transfer.Features.Account.Commands.CheckBalanceCommand;

public class CheckBalanceCommandHandler : IRequestHandler<Account.Commands.CheckBalanceCommand.CheckBalanceCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CheckBalanceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(Account.Commands.CheckBalanceCommand.CheckBalanceCommand request, CancellationToken cancellationToken)
    {
        var pm = await _context.PaymentMethods
            .AsNoTracking()
            .Where(m => m.Id == request.Id)
            .FirstAsync(cancellationToken)
                 ?? throw new Exception("Счёт не найден!");
            
        if (pm.Balance >= request.Sum)
        {
            return await Task.FromResult(true);
        }

        return await Task.FromResult(false);
    }
}