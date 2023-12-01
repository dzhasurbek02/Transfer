namespace Transfer.Entities;

public class Currency : BaseEntity
{
    public string Type { get; set; }
    
    public List<Account> Accounts { get; set; }
}