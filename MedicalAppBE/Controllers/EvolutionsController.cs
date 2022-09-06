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
    public class EvolutionsController : ControllerBase
    {
        private readonly DataContext _context;

        public EvolutionsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evolution>>> GetEvolutions()
        {
            return await _context.Evolutions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evolution>> GetEvolution(int id)
        {
            var evolution = await _context.Evolutions.FindAsync(id);
            if (evolution == null)
                return NotFound();

            return evolution;
        }

        [HttpGet("byHospitalization/{id}")]
        public async Task<ActionResult<IEnumerable<Evolution>>> GetEvolutionsByHospitalization(int id)
        {
            return await _context.Evolutions.Where((evolution) => evolution.HospitalizationId == id).OrderBy((evolution) => evolution.Date).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvolution(int id, Evolution evolution)
        {
            if (id != evolution.EvolutionId)
                return BadRequest();

            _context.Entry(evolution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvolutionExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Evolution>> AddEvolution(Evolution evolution)
        {
            if (evolution.Date > DateTime.Now)
                throw new AppException("Cannot enter value for future days");
            if (_context.Evolutions.Any(x => x.Date == evolution.Date && x.HospitalizationId == evolution.HospitalizationId))
                throw new AppException("A value for the given day already exists");

            _context.Evolutions.Add(evolution);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEvolution", new { id = evolution.EvolutionId }, evolution);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvolution(int id)
        {
            var evolution = await _context.Evolutions.FindAsync(id);
            if (evolution == null)
            {
                return NotFound();
            }
            _context.Evolutions.Remove(evolution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvolutionExists(int id)
        {
            return _context.Evolutions.Any(e => e.EvolutionId == id);
        }
    }
}