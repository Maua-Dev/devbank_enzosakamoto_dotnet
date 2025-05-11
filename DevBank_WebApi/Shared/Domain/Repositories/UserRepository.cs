using DevBank_WebApi.Shared.Helpers.Errors;

namespace DevBank_WebApi.Shared.Domain.Repositories;

using Entities;
using Interfaces;

public class UserRepository(
    ITransactionRepository transactionRepository
) : IUserRepository
{
    private static readonly User User = new()
    {
        Name = "Vitor Soller",
        Agency = "0000",
        Account = "00000-0",
        CurrentBalance = 1000.0
    };

    public async Task<User> GetUser()
    {
        return await Task.FromResult(User);
    }

    // This can be deposit/withdraw
    public async Task<Transaction> UpdateBalance(TransactionType type, double amount)
    {
        if (amount <= 0)
        {
            throw new InvalidParams();
        }

        if (type == TransactionType.Deposit)
        {
            if (amount > User.CurrentBalance * 2)
            {
                throw new SuspectAmountException(TransactionType.Deposit, amount);
            }

            User.CurrentBalance += amount;
        }
        else if (type == TransactionType.Withdraw)
        {
            if (amount > User.CurrentBalance)
            {
                throw new InsufficientFundsException(User.CurrentBalance, amount);
            }
            
            if (amount > User.CurrentBalance / 2)
            {
                throw new SuspectAmountException(TransactionType.Withdraw, amount);
            }

            User.CurrentBalance -= amount;
        }

        var transaction = await transactionRepository.Create(
            new Transaction()
            {
                Type = type,
                Value = amount,
                CurrentBalance = User.CurrentBalance,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            }
        );

        return await Task.FromResult(transaction);
    }
}