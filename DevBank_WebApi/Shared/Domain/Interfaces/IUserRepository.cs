namespace DevBank_WebApi.Shared.Domain.Interfaces;

using Entities;

public interface IUserRepository
{
    public Task<User> GetUser();

    public Task<Transaction> UpdateBalance(TransactionType type, double amount);
}