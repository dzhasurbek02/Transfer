using MediatR;

namespace Transfer.Features.User.Commands.CreateUser;

public class CreateUserCommand : IRequest
{
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
}