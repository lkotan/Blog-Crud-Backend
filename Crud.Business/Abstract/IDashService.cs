using Crud.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Business.Abstract
{
    public interface IDashService
    {
        Task<DashModel> GetDashAsync();
    }
}
