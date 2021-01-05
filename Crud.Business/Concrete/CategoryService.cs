using AutoMapper;
using Crud.Business.Abstract;
using Crud.Business.Validations;
using Crud.Core.Aspects.Validation;
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
    public class CategoryService : ICategoryService
    {
        private readonly IDataAccessRepository<Category> _dal;
        private readonly IMapper _mapper;

        public CategoryService(IDataAccessRepository<Category> dal,IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryListModel>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryListModel>>(await _dal.TableNoTracking.OrderByDescending(x => x.Id).ToListAsync());
        }

        public async Task<CategoryModel> GetAsync(int id)
        {
            return _mapper.Map<CategoryModel>(await _dal.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
        }
        public async Task<IEnumerable<DropdownModel>> SelectListAsync()
        {
            var entities = await _dal.TableNoTracking.OrderBy(x => x.Name).ToListAsync();
            return entities.Select(x => new DropdownModel
            {
                Id = x.Id,
                Description = x.Name
            });
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IDataResponse<int>> InsertAsync(CategoryModel model)
        {
            return await _dal.InsertAsync(_mapper.Map<Category>(model));
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IResponse> UpdateAsync(CategoryModel model)
        {
            var result = await _dal.UpdateAsync(_mapper.Map<Category>(model));
            return result;
        }

        public async Task<IDataResponse<int>> DeleteAsync(int id)
        {
            var entity = await _dal.GetAsync(id);
            return await _dal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<IDataResponse<int>>> DeleteRangeAsync(IEnumerable<int> list)
        {
            var result = new List<IDataResponse<int>>();
            foreach (var item in list)
            {
                result.Add(await DeleteAsync(item));
            }
            return result;
        }

      
    }
}
