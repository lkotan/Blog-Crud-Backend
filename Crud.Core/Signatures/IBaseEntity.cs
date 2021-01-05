using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Core.Signatures
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
    }
}
