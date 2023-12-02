namespace Transfer.Features.Account.CheckBalance;

public class CheckBalanceRequest
{
    public Guid Id { get; set; }
    
    public float Sum { get; set; }
}