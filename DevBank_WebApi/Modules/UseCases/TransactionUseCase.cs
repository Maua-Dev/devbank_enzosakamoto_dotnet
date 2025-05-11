using DevBank_WebApi.Shared.Domain.Entities;
using DevBank_WebApi.Shared.Domain.Interfaces;

namespace DevBank_WebApi.Modules.UseCases;

public class TransactionUseCase(
    ITransactionRepository transactionRepository
) : ITransactionUseCase
{
    public async Task<IReadOnlyList<Transaction>> GetAllTransactions()
    {
        return await transactionRepository.GetAllTransactions();
    }
}