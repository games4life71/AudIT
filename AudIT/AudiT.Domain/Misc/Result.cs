﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudIT.Domain.Misc
{
    public class Result<T> where T : class
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string Error { get; }

        public Result(bool isSuccess, T value, string error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }
        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, null!);
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T>(false, null!, error);
        }
    }
}