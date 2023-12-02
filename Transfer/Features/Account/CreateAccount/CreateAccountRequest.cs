namespace Transfer.Features.Account.CreateAccount;

public class CreateAccountRequest
{
    public Guid UserId { get; set; }
    
    public Guid CurrencyId { get; set; }
    
    public float Balance { get; set; }
}