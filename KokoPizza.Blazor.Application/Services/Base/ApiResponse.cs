namespace KokoPizza.Blazor.Application.Services.Base;

public class ApiResponse<T>
{
    public string Message { get; set; }
    public string ValidationErrors { get; set; }
    public bool Success { get; set; } = true;
    public T Data { get; set; }

    public ApiResponse()
    { 
    }

    public ApiResponse(T data)
    {
        Data = data;
    }
}