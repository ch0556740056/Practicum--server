using Common.DTO_s;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailController : ControllerBase
    {
        private readonly IDataService<PersonalDetailDto> _dataService;
        public PersonDetailController(IDataService<PersonalDetailDto> dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<PersonDetailController>
        [HttpGet]
        public async Task<List<PersonalDetailDto>> Get()
        {
            return await _dataService.GetAllAsync();

        }

        // GET api/<PersonDetailController>/5
        [HttpGet("{id}")]
        public async Task<PersonalDetailDto> Get(string id)
        {
            return await _dataService.GetByIdAsync(id);

        }

        // POST api/<PersonDetailController>
        [HttpPost]
        public async Task<PersonalDetailDto> Post([FromBody] PersonDetailModel person)
        {
            return await _dataService.AddAsync(new PersonalDetailDto { DateOfBirdth =person.DateOfBirdth, FirstName = person.FirstName, LastName = person.LastName, Hmo = person.Hmo, Gender = person.Gender, Identity=person.Identity });
        }

        // PUT api/<PersonDetailController>/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] PersonDetailModel person)
        {
            var q = new PersonalDetailDto { DateOfBirdth = person.DateOfBirdth, FirstName = person.FirstName, LastName = person.LastName, Hmo = person.Hmo, Gender = person.Gender, Identity = person.Identity };
            await _dataService.UpdateAsync(q);
        }

        // DELETE api/<PersonDetailController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _dataService.DeleteAsync(id);
        }
    }
}
