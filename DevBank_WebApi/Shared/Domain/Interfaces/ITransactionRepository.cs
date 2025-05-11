namespace DevBank_WebApi.Shared.Domain.Interfaces;

using Entities;

public interface ITransactionRepository
{
    public Task<Transaction> Create(Transaction transaction);
    public Task<IReadOnlyList<Transaction>> GetAllTransactions();
}