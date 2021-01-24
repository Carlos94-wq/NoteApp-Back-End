using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Note.Api.Response;
using Note.Core.Entities;
using Note.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogoService service;

        public CatalogoController(ICatalogoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstatus()
        {
            var All = await this.service.GetEstatus();
            var respose = new ApiResponse<IEnumerable<Estatus>>(All);

            return Ok(respose);
        }

        [HttpGet]
        public async Task<IActionResult> GetPrioridad()
        {
            var All = await this.service.Prioridad();
            var respose = new ApiResponse<IEnumerable<Prioridad>>(All);

            return Ok(respose);
        }
    }
}
