using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Core.Utilities.Results.Result
{
    public class Response : IResponse
    {
        public Response(bool success,string message):this(success)
        {
            Message = message;
        }

        public Response(bool success)
        {
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }
    }
}
