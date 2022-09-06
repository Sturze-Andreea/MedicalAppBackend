using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalAppBE.Helpers;
using MedicalAppBE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalAppBE.Authorization;
using System;

namespace MedicalAppBE.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BreathController : ControllerBase
    {
        private readonly DataContext _context;

        public BreathController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breath>>> GetBreaths()
        {
            return await _context.Breaths.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Breath>> GetBreath(int id)
        {
            var breath = await _context.Breaths.FindAsync(id);
            if (breath == null)
                return NotFound();

            return breath;
        }

        [HttpGet("byHospitalization/{id}")]
        public async Task<ActionResult<IEnumerable<Breath>>> GetBreathsbyHospitalization(int id)
        {
            return await _context.Breaths.Where((breath) => breath.HospitalizationId == id).OrderBy((breath) => breath.Date).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBreath(int id, Breath breath)
        {
            if (id != breath.BreathId)
                return BadRequest();

            _context.Entry(breath).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreathExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Breath>> AddBreath(Breath breath)
        {
            if (breath.Date > DateTime.Now)
                throw new AppException("Cannot enter value for future days");
            if (_context.Breaths.Any(x => x.Date == breath.Date && x.HospitalizationId == breath.HospitalizationId))
                throw new AppException("A value for the given day already exists");
            if (breath.BreathNr > 40 || breath.BreathNr < 5)
                throw new AppException("Wrong value entered");

            _context.Breaths.Add(breath);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBreath", new { id = breath.BreathId }, breath);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBreath(int id)
        {
            var breath = await _context.Breaths.FindAsync(id);
            if (breath == null)
            {
                return NotFound();
            }
            _context.Breaths.Remove(breath);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreathExists(int id)
        {
            return _context.Breaths.Any(e => e.BreathId == id);
        }
    }
}