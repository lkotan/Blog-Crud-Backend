using Crud.Core.Models;
using Crud.Core.Repositories;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Business.Abstract
{
    public interface ICategoryService:IServiceRepository<CategoryModel>
    {
        Task<IEnumerable<CategoryListModel>> GetAllAsync();
        Task<IEnumerable<DropdownModel>> SelectListAsync();
    }
}
