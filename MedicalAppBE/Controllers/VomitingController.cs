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
    public class VomitingController : ControllerBase
    {
        private readonly DataContext _context;

        public VomitingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vomiting>>> GetVomitings()
        {
            return await _context.Vomitings.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vomiting>> GetVomiting(int id)
        {
            var vomiting = await _context.Vomitings.FindAsync(id);
            if (vomiting == null)
                return NotFound();

            return vomiting;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVomiting(int id, Vomiting vomiting)
        {
            if (id != vomiting.VomitingId)
                return BadRequest();

            _context.Entry(vomiting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VomitingExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Vomiting>> AddVomiting(Vomiting vomiting)
        {
            _context.Vomitings.Add(vomiting);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVomiting", new { id = vomiting.VomitingId }, vomiting);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVomiting(int id)
        {
            var vomiting = await _context.Vomitings.FindAsync(id);
            if (vomiting == null)
            {
                return NotFound();
            }
            _context.Vomitings.Remove(vomiting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VomitingExists(int id)
        {
            return _context.Vomitings.Any(e => e.VomitingId == id);
        }
    }
}