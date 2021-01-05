using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Core.Utilities.Results.Result
{
    public class SuccessResponse:Response
    {
        public SuccessResponse(string message):base(true,message)
        {

        }
        public SuccessResponse():base(true)
        {

        }
    }
}
