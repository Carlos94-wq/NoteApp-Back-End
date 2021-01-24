using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Note.Api.Response;
using Note.Core.CustomEntities;
using Note.Core.Entities;
using Note.Core.Interfaces.IServices;
using Note.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService service;

        public NoteController( INoteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] NoteQueryFilters filters) 
        {
            var All = await this.service.NoteList(filters);
            var respose = new ApiResponse<IEnumerable<NoteList>>(All);

            return Ok(respose);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote(int id)
        {
            var All = await this.service.GetNota(id);
            var respose = new ApiResponse<Nota>(All);

            return Ok(respose);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Nota nota)
        {
            var Added = await this.service.Add(nota);
            var respose = new ApiResponse<bool>(Added);

            return Ok(respose);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Nota nota)
        {
            var Updated = await this.service.Update(nota);
            var respose = new ApiResponse<bool>(Updated);

            return Ok(respose);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            var Deleted= await this.service.Delete(id);
            var respose = new ApiResponse<bool>(Deleted);

            return Ok(respose);
        }
    }
}
