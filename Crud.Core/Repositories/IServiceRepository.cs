using Crud.Core.Signatures;
using Crud.Core.Utilities.Results.DataResult;
using Crud.Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Repositories
{
    public interface IServiceRepository<TModel> where TModel : class,IBaseModel,new()
    {
        Task<TModel> GetAsync(int id);
        Task<IDataResponse<int>> InsertAsync(TModel model);
        Task<IResponse> UpdateAsync(TModel model);
        Task<IDataResponse<int>> DeleteAsync(int id);
        Task<IEnumerable<IDataResponse<int>>> DeleteRangeAsync(IEnumerable<int> list);
    }
}
