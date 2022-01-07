using Elasticsearch.Models.Teacher;
using Elasticsearch.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elasticsearch.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        private readonly ISearchClient _searchClient;

        public HomeController(ISearchClient searchClient)
        {
            this._searchClient = searchClient;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _searchClient.GetById(id);
            var model = new Response.Response { Results = new List<Teacher>() { response } };
            return Ok(model);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _searchClient.GetAll();
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetByName([FromBody] Elasticsearch.Models.Filters.Filters filtro)
        {
            var response = await _searchClient.Search(filtro);
            var model = new Response.Response { Results = response };
            return Ok(model);
        }

        [HttpPost("cadastrar/")]
        public async Task<IActionResult> Get([FromBody] Teacher teacher)
        {
            var response = await _searchClient.Create(teacher);
            var model = new Response.Response { Results = new List<Teacher>(){ response } };
            return Ok(model);
        }
    }
}
