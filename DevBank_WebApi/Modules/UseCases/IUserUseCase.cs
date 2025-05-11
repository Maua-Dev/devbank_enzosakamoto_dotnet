namespace DevBank_WebApi.Modules.UseCases;

using Shared.Dtos;
using Shared.Domain.Entities;

public interface IUserUseCase
{
    public Task<User> GetUser();
    public Task<Transaction> UpdateBalance(TransactionType type, AmountDto amount);
}