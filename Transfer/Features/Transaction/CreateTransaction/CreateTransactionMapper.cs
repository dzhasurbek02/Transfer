using AutoMapper;
using Transfer.Features.Transaction.Requests;

namespace Transfer.Features.Transaction.Mappers;

public class CreateTransactionMapper : Profile
{
    public CreateTransactionMapper()
    {
        CreateMap<CreateTransactionRequest, Entities.Transaction>();
    }
}