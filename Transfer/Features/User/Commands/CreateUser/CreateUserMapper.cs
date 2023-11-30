using AutoMapper;

namespace Transfer.Features.User.Commands.CreateUser;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserCommand, Entities.User>();
    }
}