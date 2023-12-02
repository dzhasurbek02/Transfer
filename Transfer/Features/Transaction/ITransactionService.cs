using Transfer.Features.Transaction.Requests;

namespace Transfer.Features.Transaction;

public interface ITransactionService
{
    public Task<bool> CreateTransaction(CreateTransactionRequest request);
}