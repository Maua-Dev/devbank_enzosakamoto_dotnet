namespace DevBank_WebApi.Shared.Helpers.Errors;

public class InsufficientFundsException(
    double balance,
    double attemptedValue)
    : Exception($"Insufficient funds. Current balance: {balance}, attempted operation: {attemptedValue}.")
{
    public double Balance { get; set; } = balance;
    public double AttemptedValue { get; set; } = attemptedValue;
}