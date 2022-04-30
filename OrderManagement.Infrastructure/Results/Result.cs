namespace OrderManagement.Infrastructure.Results;

public class Result : IResult
{
    public Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public Result(bool success)
    {
        Success = success;
        Message = success ? "Success" : "Failed";
    }
    public bool Success { get; }
    public string Message { get; }
}

