﻿using AutoMapper;
using Crud.Core.Extensions;
using Crud.Core.Repositories;
using Crud.Core.Signatures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.API.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerRepository<TService,TModel>:ControllerBase where TModel : class,IBaseModel,new()
      where TService : class,IServiceRepository<TModel>
    {
        private readonly TService _service;
        private readonly IMapper _mapper;
        public ControllerRepository(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute] int id)
        {
            var entity = await _service.GetAsync(id);
            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Insert([FromBody] TModel model)
        {
            var result = await _service.InsertAsync(_mapper.Map<TModel>(model));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TModel model)
        {
            var result = await _service.UpdateAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost("DeleteRange")]
        public async Task<IActionResult> DeleteRange([FromBody] List<int> list)
        {
            var result = await _service.DeleteRangeAsync(list);
            return Ok(result.ToList().ToJson());
        }
    }
}
