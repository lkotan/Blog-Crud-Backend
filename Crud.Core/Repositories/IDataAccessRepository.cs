using Crud.Core.Signatures;
using Crud.Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Core.Repositories
{
    public interface IDataAccessRepository<TEntity>:IRepository<TEntity> where TEntity : class,IBaseEntity,new()
    {

    }
}
