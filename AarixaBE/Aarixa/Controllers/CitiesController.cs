using Aarixa.Models;
using Aarixa.Services.CitiesCommand;
using Microsoft.AspNetCore.Mvc;

namespace Aarixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesCommand _Cities;

        public CitiesController(ICitiesCommand Cities)
        {
            this._Cities = Cities;
        }

        // GET: api/<CitiesController>
        [HttpGet]
        public async Task<IEnumerable<City>> Get()
        {
            return await _Cities.Get();
        }

        // POST api/<CitiesController>
        [HttpPost]
        public async Task Post([FromBody] City city)
        {
            await _Cities.Create(city);
        }

        // Delete api/<CitiesController>
        [HttpDelete]
        public async Task Delete([FromQuery] int id)
        {
            await _Cities.Delete(id);
        }

        // Put api/<CitiesController>
        [HttpPut]
        public async Task Put([FromBody] City city)
        {
            await _Cities.Update(city);
        }
    }
}
