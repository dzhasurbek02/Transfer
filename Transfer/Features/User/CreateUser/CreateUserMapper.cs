using AutoMapper;

namespace Transfer.Features.User.CreateUser;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, Entities.User>();
    }
}