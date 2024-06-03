namespace Frontend.EntityDtos.Misc;

public class BaseDTOResponse<T> : BaseResponse where T : class
{
    public T? DtoResponse { get; set; }

    public List<T> DtoResponses { get; set; } = default!;
    // public string? Message { get; }
    //
    // public bool Success { get; }
    //
    // public List<string>? ValidationErrors { get; set; }

    public BaseDTOResponse(T dtoResponse) : base(null, true)
    {
        DtoResponse = dtoResponse;
        // Success = true;
        // Message = null;
    }

    /// <summary>
    /// This constructor is used when the response is not successful
    /// and we want to return a message to the presentation layer
    /// </summary>
    public BaseDTOResponse() : base(null, false)
    {
        DtoResponse = null;
        // Success = false;
        // Message = "An error occurred";
    }

    public BaseDTOResponse(string message) : base(message, false)
    {
        DtoResponse = null;
        // Success = false;
        // Message = message;
    }

    public BaseDTOResponse(T dtoResponse, string? message, bool success) : base(message, success)
    {
        DtoResponse = dtoResponse;
        // Success = success;
        // Message = message;
    }

    public BaseDTOResponse(string message, bool success) : base(message, success)
    {
        DtoResponse = null;
        // Success = success;
        // Message = message;
    }

    public BaseDTOResponse(List<T> dtoResponses, string? message, bool success) : base(message, success)
    {
        DtoResponses = dtoResponses;
        // Success = success;
        // Message = message;
    }
}