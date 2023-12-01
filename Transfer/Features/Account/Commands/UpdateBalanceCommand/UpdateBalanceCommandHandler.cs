using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transfer.Context;

namespace Transfer.Features.Account.Commands.UpdateBalanceCommand;

public class UpdateBalanceCommandHandler : IRequestHandler<Account.Commands.UpdateBalanceCommand.UpdateBalanceCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateBalanceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(Account.Commands.UpdateBalanceCommand.UpdateBalanceCommand request, CancellationToken cancellationToken)
    {
        var pm = await _context.PaymentMethods
            .Where(m => m.Id == request.Id)
            .FirstAsync(cancellationToken)
                 ?? throw new Exception("Счёт не найден!");

        pm.Balance += request.Sum;

        await _context.SaveChangesAsync(cancellationToken);
        return await Task.FromResult(true);
    }
}