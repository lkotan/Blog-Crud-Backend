using Crud.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashController:ControllerBase
    {
        private readonly IDashService _service;

        public DashController(IDashService service)
        {
            _service = service;
        }

        [HttpGet("GetDash")]
        public async Task<IActionResult> GetDash()
        {
            return Ok(await _service.GetDashAsync());
        }
    }
}
