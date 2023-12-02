using Transfer.Features.Account.CheckBalance;
using Transfer.Features.Account.CreateAccount;
using Transfer.Features.Account.UpdateBalance;

namespace Transfer.Features.Account;

public interface IAccountService
{
    public Task CreateAccount(CreateAccountRequest request);
    
    public Task<bool> CheckBalance(CheckBalanceRequest request);
    
    public Task<bool> UpdateBalance(UpdateBalanceRequest request);
}