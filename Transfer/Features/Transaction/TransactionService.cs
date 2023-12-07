using AutoMapper;
using Transfer.Context;
using Transfer.Features.Account;
using Transfer.Features.Account.CheckBalance;
using Transfer.Features.Account.UpdateBalance;
using Transfer.Features.ExchangeRate;
using Transfer.Features.ExchangeRate.GetExchangeRate;
using Transfer.Features.Transaction.Requests;

namespace Transfer.Features.Transaction;

public class TransactionService : ITransactionService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;
    private readonly IExchangeRateService _exchangeRateService;

    public TransactionService(IApplicationDbContext context,
        IMapper mapper,
        IAccountService accountService,
        IExchangeRateService exchangeRateService)
    {
        _context = context;
        _mapper = mapper;
        _accountService = accountService;
        _exchangeRateService = exchangeRateService;
    }

    public async Task<bool> CreateTransaction(CreateTransactionRequest request)
    {
        var checkBalanceRequest = new CheckBalanceRequest { Id = request.SenderId, Sum = request.Sum };
        var isBalanceSufficient = await _accountService.CheckBalance(checkBalanceRequest);

        if (isBalanceSufficient)
        {
            var senderAccount = await _context.Accounts.FindAsync(request.SenderId)
                ?? throw new Exception("Счёт оправителя не найден!");
            
            var recipientAccount = await _context.Accounts.FindAsync(request.RecipientId)
                ?? throw new Exception("Счёт получателя не найден!");
            
            if (senderAccount.CurrencyId != recipientAccount.CurrencyId)
            {
                var getExchangeRateRequest = new GetExchangeRateRequest
                    { SenderCurrencyId = senderAccount.CurrencyId, RecipientCurrencyId = recipientAccount.CurrencyId };
                var exchangeRate = await _exchangeRateService.GetExchangeRate(getExchangeRateRequest);

                var convertedSum = request.Sum * exchangeRate;
                
                
                var updateBalanceSender = new UpdateBalanceRequest { Id = request.SenderId, Sum = -request.Sum };
                await _accountService.UpdateBalance(updateBalanceSender);

                var updateBalanceReceiver = new UpdateBalanceRequest { Id = request.RecipientId, Sum = convertedSum };
                await _accountService.UpdateBalance(updateBalanceReceiver);

                var t = _mapper.Map<Entities.Transaction>(request);

                await _context.Transactions.AddAsync(t);
                await _context.SaveChangesAsync();

                return true;
            }
            
            var updateBalanceRequestSender = new UpdateBalanceRequest { Id = request.SenderId, Sum = -request.Sum };
            await _accountService.UpdateBalance(updateBalanceRequestSender);

            var updateBalanceRequestReceiver = new UpdateBalanceRequest { Id = request.RecipientId, Sum = request.Sum };
            await _accountService.UpdateBalance(updateBalanceRequestReceiver);

            var tr = _mapper.Map<Entities.Transaction>(request);

            await _context.Transactions.AddAsync(tr);
            await _context.SaveChangesAsync();

            return true;
        }

        throw new Exception("Недостаточно средств на балансе!");
    }
}