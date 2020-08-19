using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_dash.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using API_dash.UtilityClasses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_dash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunningEventsController : ControllerBase
    {

        private readonly UserContext _context;



        public RunningEventsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/RunningEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RunningEvent>>> GetRunningEvent()
        {
            return await _context.RunningEvent.ToListAsync();
        }

        // GET: api/RunningEvents
        [HttpGet("{longitudeUser}/{latitudeUser}")]
        public List<EventDTO> GetRunningEvent(float longitudeUser, float latitudeUser)
        {
            List<RunningEvent> listRunningEvent =  _context.RunningEvent.ToList();
            List<EventDTO> simpleList= new List<EventDTO>();

            foreach (RunningEvent runEvent in listRunningEvent)
            {
                var simp = new EventDTO
                {
                    City = runEvent.City,
                    Date = runEvent.date,
                    URL = runEvent.URL,
                    Name = runEvent.Name,
                    Distance = GeoLocationService.CalculatePointDistance(runEvent.longitude, longitudeUser, runEvent.latitude, latitudeUser)
                };


                simpleList.Add(simp);
            }

            List<EventDTO> list = simpleList.OrderBy(x => x.Distance).ToList();
            return list.Take(10).ToList();
        }







        [HttpPost]
        public async Task<ActionResult<RunningEvent>> PostUser(RunningEvent x)
        {



                _context.RunningEvent.Add(x);
                await _context.SaveChangesAsync();


                return StatusCode(200);


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
