using AutoMapper;

namespace Transfer.Features.Transaction.Command.CreateTransaction;

public class CreateTransactionMapper : Profile
{
    public CreateTransactionMapper()
    {
        CreateMap<CreateTransactionCommand, Entities.Transaction>();
    }
}