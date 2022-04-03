using KokoPizza.Blazor.Application.Services.Base;

namespace KokoPizza.Blazor.Application.Extensions;

public static class RequestExtension
{
    public static async Task<ApiResponse<long>> TrySend(this Func<Task> func)
    {
        try
        {
            await func();
            return new ApiResponse<long>();
        }
        catch (ApiException ex)
        {
            return ConvertApiException<long>(ex);
        }
    }

    public static async Task<ApiResponse<T>> TrySend<T>(this Func<Task<T>> func)
    {
        try
        {
            var data = await func();
            return new ApiResponse<T>(data);
        }
        catch (ApiException ex)
        {
            return ConvertApiException<T>(ex);
        }
    }

    private static ApiResponse<T> ConvertApiException<T>(ApiException ex)
        => ex.StatusCode switch
        {
            400 => new ApiResponse<T>
                { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false },
            404 => new ApiResponse<T>
                { Message = "The requested item could not be found.", ValidationErrors = ex.Response, Success = false },
            _ => new ApiResponse<T>
                { Message = "Something went wrong.", ValidationErrors = ex.Response, Success = false },
        };
}