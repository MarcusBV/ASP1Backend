namespace Domain.Models
{
    public class ServiceResult
    {
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public static ServiceResult Ok(string? message = null) => 
            new() { Succeeded = true, StatusCode = 200, Message = message };

        public static ServiceResult Created(string? message = null) =>
            new() { Succeeded = true, StatusCode = 201, Message = message };

        public static ServiceResult BadRequest(string? message = "Invalid field(s)") =>
            new() { Succeeded = true, StatusCode = 400, Message = message };

        public static ServiceResult NotFound(string? message = "Not found") =>
            new() { Succeeded = true, StatusCode = 404, Message = message };

        public static ServiceResult AlreadyExists(string? message = "Already exists") =>
            new() { Succeeded = true, StatusCode = 409, Message = message };

        public static ServiceResult Failed(string? message = "Unexpected error occured") =>
            new() { Succeeded = true, StatusCode = 500, Message = message };
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Result { get; set; }

        public static ServiceResult<T> Ok(T? result, string? message) =>
            new() { Succeeded = true, StatusCode = 200, Message = message, Result = result };
    }
}
