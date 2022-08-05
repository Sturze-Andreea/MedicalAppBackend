using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalAppBE.Helpers;
using MedicalAppBE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalizationsController: ControllerBase
    {
        
        private readonly DataContext _context;

        public HospitalizationsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospitalization>>> GetHospitalizations()
        {
            return await _context.Hospitalizations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hospitalization>> GetHospitalization(int id)
        {
            var hospitalization = await _context.Hospitalizations.FindAsync(id);
            if (hospitalization == null)
                return NotFound();

            return hospitalization;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHospitalization(int id, Hospitalization hospitalization)
        {
            if (id != hospitalization.HospitalizationId)
                return BadRequest();

            _context.Entry(hospitalization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalizationExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Hospitalization>> AddHospitalization(Hospitalization hospitalization)
        {
            _context.Hospitalizations.Add(hospitalization);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHospitalization", new { id = hospitalization.HospitalizationId }, hospitalization);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHospitalization(int id)
        {
            var hospitalization = await _context.Hospitalizations.FindAsync(id);
            if (hospitalization == null)
            {
                return NotFound();
            }
            _context.Hospitalizations.Remove(hospitalization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalizationExists(int id)
        {
            return _context.Hospitalizations.Any(e => e.HospitalizationId == id);
        }
    }
}