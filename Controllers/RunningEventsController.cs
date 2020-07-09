using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_dash.Models;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_dash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunningEventsController : ControllerBase
    {
        // GET: api/<RunningEventsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2","value3", "value4", "value5", "value6", "value7", "value8" };
        }

        // GET api/<RunningEventsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RunningEventsController>
        [HttpPost]
        public void Post([FromBody] int id, [FromBody] string name, string location, string city, string postcode, DateTime dateTime, float distance, bool virtualRace)
        {
        }

        // PUT api/<RunningEventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name, string location, string city, string postcode, DateTime dateTime, float distance, bool virtualRace)
        {
        }

        // DELETE api/<RunningEventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
