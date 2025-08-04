using System;
using System.Net;

namespace BuildingsService.Domain;

public class Response<T>
{
    public bool IsSuccess { get; set; }
    public required string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public required T Data { get; set; }

    public static Response<T> Success(T data, string message = "Operation successful")
    {
        return new Response<T>
        {
            IsSuccess = true,
            Message = message,
            StatusCode = HttpStatusCode.OK,
            Data = data
        };
    }

    public static Response<T> Failure(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new Response<T>
        {
            IsSuccess = false,
            Message = message,
            StatusCode = statusCode,
            Data = default!
        };
    }
}
