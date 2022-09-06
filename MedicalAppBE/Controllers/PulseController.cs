using System.Collections.Generic;
using System;
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
    public class PulseController : ControllerBase
    {
        private readonly DataContext _context;

        public PulseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pulse>>> GetPulses()
        {
            return await _context.Pulses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pulse>> GetPulse(int id)
        {
            var pulse = await _context.Pulses.FindAsync(id);
            if (pulse == null)
                return NotFound();

            return pulse;
        }

        [HttpGet("byHospitalization/{id}")]
        public async Task<ActionResult<IEnumerable<Pulse>>> GetPulsesbyHospitalization(int id)
        {
            return await _context.Pulses.Where((pulse) => pulse.HospitalizationId == id).OrderBy((pulse) => pulse.Date).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePulse(int id, Pulse pulse)
        {
            if (id != pulse.PulseId)
                return BadRequest();

            _context.Entry(pulse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PulseExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Pulse>> AddPulse(Pulse pulse)
        {
            if (pulse.Date > DateTime.Now)
                throw new AppException("Cannot enter value for future days");
            if (_context.Pulses.Any(x => x.Date == pulse.Date && x.HospitalizationId == pulse.HospitalizationId))
                throw new AppException("A value for the given day already exists");
            if (pulse.Puls > 180 || pulse.Puls < 40)
                throw new AppException("Wrong value entered");

            _context.Pulses.Add(pulse);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPulse", new { id = pulse.PulseId }, pulse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePulse(int id)
        {
            var pulse = await _context.Pulses.FindAsync(id);
            if (pulse == null)
            {
                return NotFound();
            }
            _context.Pulses.Remove(pulse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PulseExists(int id)
        {
            return _context.Pulses.Any(e => e.PulseId == id);
        }
    }
}