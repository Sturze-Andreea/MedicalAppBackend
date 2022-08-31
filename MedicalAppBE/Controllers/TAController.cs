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
    public class TAController : ControllerBase
    {
        private readonly DataContext _context;

        public TAController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TA>>> GetTAs()
        {
            return await _context.TAs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TA>> GetTA(int id)
        {
            var ta = await _context.TAs.FindAsync(id);
            if (ta == null)
                return NotFound();

            return ta;
        }

        [HttpGet("byHospitalization/{id}")]
        public async Task<ActionResult<IEnumerable<TA>>> GetTAsbyHospitalization(int id)
        {
            return await _context.TAs.Where((ta) => ta.HospitalizationId == id).OrderBy((ta) => ta.Date).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTA(int id, TA ta)
        {
            if (id != ta.TAId)
                return BadRequest();

            _context.Entry(ta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TAExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TA>> AddTA(TA ta)
        {
            if (_context.TAs.Any(x => x.Date <= new System.DateTime()))
                throw new AppException("Cannot enter value for future days");

            _context.TAs.Add(ta);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTA", new { id = ta.TAId }, ta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTA(int id)
        {
            var ta = await _context.TAs.FindAsync(id);
            if (ta == null)
            {
                return NotFound();
            }
            _context.TAs.Remove(ta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TAExists(int id)
        {
            return _context.TAs.Any(e => e.TAId == id);
        }
    }
}