using Crud.Core.Models;
using Crud.Core.Repositories;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Business.Abstract
{
    public interface IBlogService:IServiceRepository<BlogModel>
    {
        Task<IEnumerable<BlogListModel>> GetAllAsync(int? authorId, int? categoryId, string keyword);
        Task<IEnumerable<DropdownModel>> SelectListAsync();
    }
}
