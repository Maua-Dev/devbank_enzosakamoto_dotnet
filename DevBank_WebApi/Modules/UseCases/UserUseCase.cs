using System.Text.Json;

namespace DevBank_WebApi.Modules.UseCases;

using DevBank_WebApi.Shared.Dtos;
using Shared.Domain.Entities;
using Shared.Domain.Interfaces;

public class UserUseCase(IUserRepository userRepository): IUserUseCase
{
    public async Task<User> GetUser()
    {
        return await userRepository.GetUser();
    }

    public async Task<Transaction> UpdateBalance(TransactionType type, AmountDto amount)
    {
        var parsedAmount = amount.Total();
        return await userRepository.UpdateBalance(type, parsedAmount);
    }
}