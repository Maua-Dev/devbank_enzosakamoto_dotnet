namespace DevBank_WebApi.Shared.Helpers;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string Message { get; set; }
}

public class ApiResponse
{
    public string Message { get; set; }
}