using AutoMapper;
using Crud.API.Repositories;
using Crud.Business.Abstract;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController:ControllerRepository<IBlogService,BlogModel>
    {
        private readonly IBlogService _service;

        public BlogsController(IBlogService service,IMapper mapper):base(service,mapper)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? authorId,[FromQuery] int? categoryId,[FromQuery] string keyword)
        {
            return Ok(await _service.GetAllAsync(authorId,categoryId,keyword));
        }

        [HttpGet("SelectList")]
        public async Task<IActionResult> SelectList()
        {
            return Ok(await _service.SelectListAsync());
        }
    }
}
