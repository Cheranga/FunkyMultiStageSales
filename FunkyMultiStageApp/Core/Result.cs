using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace FunkyMultiStageApp.Core
{
    public class Result
    {
        public Error Error { get; set; }

        public bool Status { get; set; }

        public static Result Success()
        {
            return new Result
            {
                Status = true,
                Error = null
            };
        }

        public static Result Failure(string errorCode, params string[] messages)
        {
            return new Result
            {
                Status = false,
                Error = new Error
                {
                    ErrorCode = errorCode,
                    Messages = messages
                }
            };
        }
    }


    public class Result<T> : Result where T:class
    {
        public T Data { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                Data = data,
                Status = true,
                Error = null
            };
        }

        public new static Result<T> Failure(string errorCode, params string[] messages)
        {
            return new Result<T>
            {
                Data = null,
                Status = false,
                Error = new Error
                {
                    ErrorCode = errorCode,
                    Messages = messages
                }
            };
        }
    }

    public class Error
    {
        public string ErrorCode { get; set; }
        public string[] Messages { get; set; }
    }
}
