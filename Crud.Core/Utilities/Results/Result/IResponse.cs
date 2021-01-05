using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Core.Utilities.Results.Result
{
    public interface IResponse
    {
        bool Success { get; }
        string Message { get; }
    }
}
