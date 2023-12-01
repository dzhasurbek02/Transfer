namespace Transfer.Entities;

public class User : BaseEntity
{
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public List<Account> Accounts { get; set; }
}