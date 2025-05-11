namespace DevBank_WebApi.Modules.UseCases;

using Shared.Domain.Entities;

public interface ITransactionUseCase
{
    public Task<IReadOnlyList<Transaction>> GetAllTransactions();
}