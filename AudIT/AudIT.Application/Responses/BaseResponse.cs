namespace AudIT.Applicationa.Responses;

/// <summary>
/// Refactored the response class so that it models
/// the response without a DTO class in case of DELETE or REMOVE operations(
/// which don't return any data, just a simple message)
/// </summary>
public class BaseResponse
{
    public string? Message { get; set; }

    public bool Success { get; set; }

    public List<string>? ValidationErrors { get; set; }

    public  BaseResponse()
    {
        Success = true;
        Message = null;
    }

    public BaseResponse(string? message, bool success)
    {
        Success = success;
        Message = message;
    }
}