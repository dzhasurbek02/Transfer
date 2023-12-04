using AutoMapper;
using Transfer.Context;
using Transfer.Features.Account;
using Transfer.Features.Account.CheckBalance;
using Transfer.Features.Account.UpdateBalance;
using Transfer.Features.Transaction.Requests;

namespace Transfer.Features.Transaction;

public class TransactionService : ITransactionService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAccountService _service;

    public TransactionService(IApplicationDbContext context, IMapper mapper, IAccountService service)
    {
        _context = context;
        _mapper = mapper;
        _service = service;
    }

    public async Task<bool> CreateTransaction(CreateTransactionRequest request)
    {
        var checkBalanceRequest = new CheckBalanceRequest { Id = request.SenderId, Sum = request.Sum };
        var isBalanceSufficient = await _service.CheckBalance(checkBalanceRequest);

        if (isBalanceSufficient)
        {
            var updateBalanceRequestSender = new UpdateBalanceRequest { Id = request.SenderId, Sum = -request.Sum };
            await _service.UpdateBalance(updateBalanceRequestSender);

            var updateBalanceRequestReceiver = new UpdateBalanceRequest { Id = request.RecipientId, Sum = request.Sum };
            await _service.UpdateBalance(updateBalanceRequestReceiver);

            var tr = _mapper.Map<Entities.Transaction>(request);

            await _context.Transactions.AddAsync(tr);
            await _context.SaveChangesAsync();

            return true;
        }
        
        return false;
    }
}