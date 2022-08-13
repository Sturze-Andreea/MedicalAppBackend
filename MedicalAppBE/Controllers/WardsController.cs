using System.Collections.Generic;
using MedicalAppBE.Authorization;
using System.Linq;
using System.Threading.Tasks;
using MedicalAppBE.Helpers;
using MedicalAppBE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBE.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WardsController : ControllerBase
    {
        private readonly DataContext _context;

        public WardsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ward>>> GetWards()
        {
            return await _context.Wards.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ward>> GetWard(int id)
        {
            var ward = await _context.Wards.FindAsync(id);
            if (ward == null)
                return NotFound();

            return ward;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWard(int id, Ward ward)
        {
            if (id != ward.WardId)
                return BadRequest();

            _context.Entry(ward).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WardExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Ward>> AddWard(Ward ward)
        {
            _context.Wards.Add(ward);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetWard", new { id = ward.WardId }, ward);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWard(int id)
        {
            var ward = await _context.Wards.FindAsync(id);
            if (ward == null)
            {
                return NotFound();
            }
            _context.Wards.Remove(ward);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WardExists(int id)
        {
            return _context.Wards.Any(e => e.WardId == id);
        }
    }
}