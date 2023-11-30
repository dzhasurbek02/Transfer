using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transfer.Context;

namespace Transfer.Features.PaymentMethod.Commands.CheckBalanceCommand;

public class CheckBalanceCommandHandler : IRequestHandler<CheckBalanceCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CheckBalanceCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(CheckBalanceCommand request, CancellationToken cancellationToken)
    {
        var pm = _context.PaymentMethods
            .AsNoTracking()
            .Where(m => m.Id == request.Id)
            .FirstAsync(cancellationToken)
                 ?? throw new Exception("Счёт не найден!");
            
        if (pm.Result.Balance >= request.Sum)
        {
            return await Task.FromResult(true);
        }

        return await Task.FromResult(false);
    }
}