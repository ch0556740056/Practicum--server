using Common.DTO_s;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IDataService<ChildDto> _dataService;
        public ChildController(IDataService<ChildDto> dataService)
        {
            _dataService = dataService;
        }
        // GET: api/<ChildController>
        [HttpGet]
        public async Task<List<ChildDto>> Get()
        {
            return await _dataService.GetAllAsync();

        }

        // GET api/<ChildController>/5
        [HttpGet("{id}")]
        public async Task<ChildDto> Get(string id)
        {
            return await _dataService.GetByIdAsync(id);

        }

        // POST api/<ChildController>
        [HttpPost]
        public async Task<ChildDto> Post([FromBody] ChildModel child)
        {
            return await _dataService.AddAsync(new ChildDto { DateOfBirdth = child.DateOfBirdth, Name = child.Name, ParentId = child.ParentId, Identity = child.Identity });
        }

        // PUT api/<ChildController>/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] ChildModel child)
        {
            var q = new ChildDto { DateOfBirdth = child.DateOfBirdth, Name = child.Name, ParentId = child.ParentId, Identity = child.Identity };
            await _dataService.UpdateAsync(q);
        }

        // DELETE api/<ChildController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _dataService.DeleteAsync(id);
        }
    }
}
