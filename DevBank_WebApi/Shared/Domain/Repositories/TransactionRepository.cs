namespace DevBank_WebApi.Shared.Domain.Repositories;

using Entities;
using Interfaces;

public class TransactionRepository : ITransactionRepository
{
    private static readonly List<Transaction> Transactions = [];
    public async Task<Transaction> Create(Transaction transaction)
    {
        Transactions.Add(transaction);
        return await Task.FromResult(transaction);
    }
    
    public async Task<IReadOnlyList<Transaction>> GetAllTransactions() 
    {
        return await Task.FromResult(Transactions);
    }
}