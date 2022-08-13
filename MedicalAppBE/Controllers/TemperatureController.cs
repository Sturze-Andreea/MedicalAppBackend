using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalAppBE.Helpers;
using MedicalAppBE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalAppBE.Authorization;

namespace MedicalAppBE.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly DataContext _context;

        public TemperatureController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temperature>>> GetTemperatures()
        {
            return await _context.Temperatures.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Temperature>> GetTemperature(int id)
        {
            var temperature = await _context.Temperatures.FindAsync(id);
            if (temperature == null)
                return NotFound();

            return temperature;
        }

        [HttpGet("byHospitalization/{id}")]
        public async Task<ActionResult<IEnumerable<Temperature>>> GetTemperaturesbyHospitalization(int id)
        {
            return await _context.Temperatures.Where((temp) => temp.HospitalizationId == id).OrderBy((temp) => temp.Date).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTemperature(int id, Temperature temperature)
        {
            if (id != temperature.TemperatureId)
                return BadRequest();

            _context.Entry(temperature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperatureExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Temperature>> AddTemperature(Temperature temperature)
        {
            _context.Temperatures.Add(temperature);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTemperature", new { id = temperature.TemperatureId }, temperature);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTemperature(int id)
        {
            var temperature = await _context.Temperatures.FindAsync(id);
            if (temperature == null)
            {
                return NotFound();
            }
            _context.Temperatures.Remove(temperature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemperatureExists(int id)
        {
            return _context.Temperatures.Any(e => e.TemperatureId == id);
        }
    }
}