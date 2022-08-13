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
    public class AdministeringsController : ControllerBase
    {
        private readonly DataContext _context;

        public AdministeringsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administering>>> GetAdministerings()
        {
            return await _context.Administerings.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Administering>> GetAdministering(int id)
        {
            var administering = await _context.Administerings.FindAsync(id);
            if (administering == null)
                return NotFound();

            return administering;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdministering(int id, Administering administering)
        {
            if (id != administering.AdministeringId)
                return BadRequest();

            _context.Entry(administering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministeringExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Administering>> AddAdministering(Administering administering)
        {
            _context.Administerings.Add(administering);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAdministering", new { id = administering.AdministeringId }, administering);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdministering(int id)
        {
            var administering = await _context.Administerings.FindAsync(id);
            if (administering == null)
            {
                return NotFound();
            }
            _context.Administerings.Remove(administering);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministeringExists(int id)
        {
            return _context.Administerings.Any(e => e.AdministeringId == id);
        }
    }
}