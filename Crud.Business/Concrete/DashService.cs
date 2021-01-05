using Crud.Business.Abstract;
using Crud.Core.Repositories;
using Crud.Entities;
using Crud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Business.Concrete
{
    public class DashService : IDashService
    {
        private readonly IDataAccessRepository<Blog> _dalBlog;
        private readonly IDataAccessRepository<Category> _dalCategory;
        private readonly IDataAccessRepository<Author> _dalAuthor;

        public DashService(IDataAccessRepository<Blog> dalBlog, IDataAccessRepository<Category> dalCategory, IDataAccessRepository<Author> dalAuthor)
        {
            _dalBlog = dalBlog;
            _dalCategory = dalCategory;
            _dalAuthor = dalAuthor;
        }
        public async Task<DashModel> GetDashAsync()
        {
            var blog = await _dalBlog.TableNoTracking.CountAsync();
            var category =await _dalCategory.TableNoTracking.CountAsync();
            var author = await _dalAuthor.TableNoTracking.CountAsync();
            var model= new DashModel
            {
                AuthorCount=author,
                BlogCount=blog,
                CategoryCount=category
            };
            return model;
            
        }
    }
}
