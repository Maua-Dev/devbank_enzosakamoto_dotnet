using DevBank_WebApi.Shared.Domain.Entities;

namespace DevBank_WebApi.Shared.Helpers.Errors;

public class SuspectAmountException(
    TransactionType type,
    double attemptedValue
) : Exception($"Suspect {type.ToString()}. Attempted value: {attemptedValue}.")
{
    public TransactionType Type { get; set; } = type;
    public double AttemptedValue { get; set; } = attemptedValue;
}