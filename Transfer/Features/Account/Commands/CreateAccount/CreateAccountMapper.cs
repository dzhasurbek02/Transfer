using AutoMapper;

namespace Transfer.Features.Account.Commands.CreateAccount;

public class CreateAccountMapper : Profile
{
    public CreateAccountMapper()
    {
        CreateMap<CreateAccountCommand, Entities.Account>();
    }
}