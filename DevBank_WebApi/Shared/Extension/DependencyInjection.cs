namespace DevBank_WebApi.Shared.Extension;

using Modules.UseCases;
using Domain.Interfaces;
using Domain.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddUserFeatures(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IUserUseCase, UserUseCase>();
        services.AddSingleton<ITransactionRepository, TransactionRepository>();
        services.AddSingleton<ITransactionUseCase, TransactionUseCase>();
        
        return services;
    }
}