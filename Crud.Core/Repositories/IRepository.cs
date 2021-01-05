using Crud.Core.Signatures;
using Crud.Core.Utilities.Results.DataResult;
using Crud.Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class,IBaseEntity,new()
    {
        #region Properties
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        #endregion

        #region Methods
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetAsync(int id);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);

        Task<bool> AynAsync(int id);

        Task<IDataResponse<int>> InsertAsync(TEntity entity);

        Task<IResponse> UpdateAsync(TEntity entity);

        Task<IDataResponse<int>> DeleteAsync(TEntity entity);

        IEnumerable<TEntity> GetSql(string sql);
        #endregion

    }
}
