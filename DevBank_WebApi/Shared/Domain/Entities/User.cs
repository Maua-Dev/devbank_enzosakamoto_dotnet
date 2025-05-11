namespace DevBank_WebApi.Shared.Domain.Entities;

public record User
{
    public string Name { get; set; }
    public string Agency { get; set; }
    public string Account { get; set; }
    public double CurrentBalance { get; set; }
}