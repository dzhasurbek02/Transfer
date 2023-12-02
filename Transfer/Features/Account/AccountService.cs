using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Transfer.Context;
using Transfer.Features.Account.CheckBalance;
using Transfer.Features.Account.CreateAccount;
using Transfer.Features.Account.UpdateBalance;

namespace Transfer.Features.Account;

public class AccountService : IAccountService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AccountService(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task CreateAccount(CreateAccountRequest request)
    {
        var account = _mapper.Map<Entities.Account>(request);

        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckBalance(CheckBalanceRequest request)
    {
        var account = await _context.Accounts
            .AsNoTracking()
            .Where(m => m.Id == request.Id)
            .FirstAsync()
                 ?? throw new Exception("Счёт не найден!");
            
        if (account.Balance >= request.Sum)
        {
            return await Task.FromResult(true);
        }

        return await Task.FromResult(false);
    }

    public async Task<bool> UpdateBalance(UpdateBalanceRequest request)
    {
        var account = await _context.Accounts
            .Where(m => m.Id == request.Id)
            .FirstAsync()
                 ?? throw new Exception("Счёт не найден!");

        account.Balance += request.Sum;

        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }
}