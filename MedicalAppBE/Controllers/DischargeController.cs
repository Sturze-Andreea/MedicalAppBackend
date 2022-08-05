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
    public class DischargeController : ControllerBase
    {
        private readonly DataContext _context;

        public DischargeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discharge>>> GetDischarges()
        {
            return await _context.Discharges.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Discharge>> GetDischarge(int id)
        {
            var discharge = await _context.Discharges.FindAsync(id);
            if (discharge == null)
                return NotFound();

            return discharge;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDischarge(int id, Discharge discharge)
        {
            if (id != discharge.DischargeId)
                return BadRequest();

            _context.Entry(discharge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DischargeExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Discharge>> AddDischarge(Discharge discharge)
        {
            _context.Discharges.Add(discharge);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDischarge", new { id = discharge.DischargeId }, discharge);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDischarge(int id)
        {
            var discharge = await _context.Discharges.FindAsync(id);
            if (discharge == null)
            {
                return NotFound();
            }
            _context.Discharges.Remove(discharge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DischargeExists(int id)
        {
            return _context.Discharges.Any(e => e.DischargeId == id);
        }
    }
}