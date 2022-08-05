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
    public class DiuresisController : ControllerBase
    {
        private readonly DataContext _context;

        public DiuresisController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diuresis>>> GetDiuresiss()
        {
            return await _context.Diuresises.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Diuresis>> GetDiuresis(int id)
        {
            var diuresis = await _context.Diuresises.FindAsync(id);
            if (diuresis == null)
                return NotFound();

            return diuresis;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDiuresis(int id, Diuresis diuresis)
        {
            if (id != diuresis.DiuresisId)
                return BadRequest();

            _context.Entry(diuresis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiuresisExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Diuresis>> AddDiuresis(Diuresis diuresis)
        {
            _context.Diuresises.Add(diuresis);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDiuresis", new { id = diuresis.DiuresisId }, diuresis);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiuresis(int id)
        {
            var diuresis = await _context.Diuresises.FindAsync(id);
            if (diuresis == null)
            {
                return NotFound();
            }
            _context.Diuresises.Remove(diuresis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiuresisExists(int id)
        {
            return _context.Diuresises.Any(e => e.DiuresisId == id);
        }
    }
}