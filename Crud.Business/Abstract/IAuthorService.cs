using Crud.Core.Models;
using Crud.Core.Repositories;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Business.Abstract
{
    public interface IAuthorService:IServiceRepository<AuthorModel>
    {
        Task<IEnumerable<AuthorListModel>> GetAllAsync();
        Task<IEnumerable<DropdownModel>> SelectListAsync();
    }
}
