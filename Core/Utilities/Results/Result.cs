using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message) : this(success) //ctor un tek parametreli class ına success i gönder 
        {
            Message = message;
        }

        public Result(bool success) //overloading aşırı yükleme yaptık
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
