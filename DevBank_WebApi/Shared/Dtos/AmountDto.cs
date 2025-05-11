namespace DevBank_WebApi.Shared.Dtos;

using System.Text.Json.Serialization;

public record AmountDto
{
    [JsonPropertyName("2")] public int Two { get; set; } = 0;

    [JsonPropertyName("5")] public int Five { get; set; } = 0;

    [JsonPropertyName("10")] public int Ten { get; set; } = 0;

    [JsonPropertyName("20")] public int Twenty { get; set; } = 0;

    [JsonPropertyName("50")] public int Fifty { get; set; } = 0;

    [JsonPropertyName("100")] public int OneHundred { get; set; } = 0;

    [JsonPropertyName("200")] public int TwoHundred { get; set; } = 0;

    public int Total() =>
        Two * 2 +
        Five * 5 +
        Ten * 10 +
        Twenty * 20 +
        Fifty * 50 +
        OneHundred * 100 +
        TwoHundred * 200;
}