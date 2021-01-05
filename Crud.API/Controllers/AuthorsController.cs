using AutoMapper;
using Crud.API.Repositories;
using Crud.Business.Abstract;
using Crud.Business.Concrete;
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
    public class AuthorsController:ControllerRepository<IAuthorService,AuthorModel>
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service,IMapper mapper):base(service,mapper)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("SelectList")]
        public async Task<IActionResult> SelectList()
        {
            return Ok(await _service.SelectListAsync());
        }
    }
}
