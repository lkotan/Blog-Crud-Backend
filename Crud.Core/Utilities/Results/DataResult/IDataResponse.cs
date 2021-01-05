using Crud.Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Core.Utilities.Results.DataResult
{
    public interface IDataResponse<out T>:IResponse
    {
        T Data { get; }
    }
}
