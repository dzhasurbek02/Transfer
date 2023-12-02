namespace Transfer.Features.Account.UpdateBalance;

public class UpdateBalanceRequest
{
    public Guid Id { get; set; }
    
    public float Sum { get; set; }
}