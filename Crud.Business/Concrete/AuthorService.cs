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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Business.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly IDataAccessRepository<Author> _dal;
        private readonly IMapper _mapper;
        public AuthorService(IDataAccessRepository<Author> dal,IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorListModel>> GetAllAsync()
        {
            return _mapper.Map<List<AuthorListModel>>(await _dal.TableNoTracking.OrderByDescending(x => x.Id).ToListAsync());
        }

        public async Task<AuthorModel> GetAsync(int id)
        {
            return _mapper.Map<AuthorModel>(await _dal.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IEnumerable<DropdownModel>> SelectListAsync()
        {
            var entities = await _dal.TableNoTracking.OrderBy(x => x.FirstName).ToListAsync();
            return entities.Select(x => new DropdownModel
            {
                Id = x.Id,
                Description = $"{x.FirstName} {x.LastName}"
            });
        }

        [ValidationAspect(typeof(AuthorValidator))]
        public async Task<IDataResponse<int>> InsertAsync(AuthorModel model)
        {
            return await _dal.InsertAsync(_mapper.Map<Author>(model));
        }
        [ValidationAspect(typeof(AuthorValidator))]
        public async Task<IResponse> UpdateAsync(AuthorModel model)
        {
            return await _dal.UpdateAsync(_mapper.Map<Author>(model));
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
