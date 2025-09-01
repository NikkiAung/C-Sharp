using System;

namespace Domain.Models;

public class ResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }


    public ResponseModel(bool isSuccess, string? message, object? data = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
}
