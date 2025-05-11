using System.Text.Json.Serialization;

namespace DevBank_WebApi.Shared.Domain.Entities;

public record Transaction
{
    public TransactionType Type { get; set; }
    public double Value { get; set; }
    public double CurrentBalance { get; set; }
    public long Timestamp { get; set; }
}


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionType
{
    [JsonStringEnumMemberName("deposit")]
    Deposit = 0,
    [JsonStringEnumMemberName("withdraw")]
    Withdraw = 1
}