﻿namespace OrderManagement.Infrastructure.Results;
public interface IResult
{
    bool Success { get; }
    string Message { get; }
}
