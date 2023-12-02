namespace Transfer.Features.User.CreateUser;

public class CreateUserRequest
{
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
}