using Transfer.Features.User.CreateUser;

namespace Transfer.Features.User;

public interface IUserService
{
    public Task CreateUser(CreateUserRequest request);
}