using AutoMapper;

namespace Transfer.Features.Account.CreateAccount;

public class CreateAccountMapper : Profile
{
    public CreateAccountMapper()
    {
        CreateMap<CreateAccountRequest, Entities.Account>();
    }
}