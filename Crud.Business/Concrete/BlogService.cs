using AutoMapper;
using Castle.Core.Internal;
using Crud.Business.Abstract;
using Crud.Business.Validations;
using Crud.Core.Aspects.Validation;
using Crud.Core.Messages;
using Crud.Core.Models;
using Crud.Core.Repositories;
using Crud.Core.Utilities.Results.DataResult;
using Crud.Core.Utilities.Results.Result;
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
    public class BlogService : IBlogService
    {
        private readonly IDataAccessRepository<Blog> _dal;
        private readonly IMapper _mapper;
        public BlogService(IDataAccessRepository<Blog> dal,IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogListModel>> GetAllAsync(int? authorId,int? categoryId,string keyword)
        {
            var query = _dal.TableNoTracking
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Where(x => authorId != null ? x.AuthorId == authorId : x.Id > 0)
                .Where(x => categoryId != null ? x.CategoryId == categoryId : x.Id > 0)
                .Where(x => !keyword.IsNullOrEmpty() ? x.Title.ToLower().Contains(keyword.ToLower()) || x.Description.ToLower().Contains(keyword.ToLower()) : x.Id > 0).OrderByDescending(x=>x.Id);

            return _mapper.Map<List<BlogListModel>>(await query.ToListAsync());
        }

        public async Task<BlogModel> GetAsync(int id)
        {
            return _mapper.Map<BlogModel>(await _dal.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<DropdownModel>> SelectListAsync()
        {
            var entities = await _dal.TableNoTracking.OrderBy(x => x.Title).ToListAsync();
            return entities.Select(x => new DropdownModel
            {
                Id = x.Id,
                Description = x.Title
            });
        }

        [ValidationAspect(typeof(BlogValidator))]
        public async Task<IDataResponse<int>> InsertAsync(BlogModel model)
        {
            return await _dal.InsertAsync(_mapper.Map<Blog>(model));
        }
        [ValidationAspect(typeof(BlogValidator))]
        public async Task<IResponse> UpdateAsync(BlogModel model)
        {
            return await _dal.UpdateAsync(_mapper.Map<Blog>(model));
        }
        public async Task<IDataResponse<int>> DeleteAsync(int id)
        {
            var entity = await _dal.GetAsync(id);
            if (entity == null) return new ErrorDataResponse<int>(DbMessage.DataNotFound);
            return await _dal.DeleteAsync(entity);
        }
        public async Task<IEnumerable<IDataResponse<int>>> DeleteRangeAsync(IEnumerable<int> list)
        {
            var result= new List<IDataResponse<int>>();
            foreach (var item in list)
            {
                result.Add(await DeleteAsync(item));
            }
            return result;
        }
    }
}
