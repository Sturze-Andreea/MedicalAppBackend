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
    public class LiquidsController: ControllerBase
    {
       
private readonly DataContext _context;

        public LiquidsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Liquids>>> GetLiquids()
        {
            return await _context.Liquids.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Liquids>> GetLiquids(int id)
        {
            var liquids = await _context.Liquids.FindAsync(id);
            if (liquids == null)
                return NotFound();

            return liquids;
        }

        [HttpGet("byHospitalization/{id}")]
        public async Task<ActionResult<IEnumerable<Liquids>>> GetLiquidsbyHospitalization(int id)
        {
            return await _context.Liquids.Where((liquids) => liquids.HospitalizationId == id).OrderBy((liquids) => liquids.Date).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLiquids(int id, Liquids liquids)
        {
            if (id != liquids.LiquidsId)
                return BadRequest();

            _context.Entry(liquids).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiquidsExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Liquids>> AddLiquids(Liquids liquids)
        {
            _context.Liquids.Add(liquids);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLiquids", new { id = liquids.LiquidsId }, liquids);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLiquids(int id)
        {
            var liquids = await _context.Liquids.FindAsync(id);
            if (liquids == null)
            {
                return NotFound();
            }
            _context.Liquids.Remove(liquids);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LiquidsExists(int id)
        {
            return _context.Liquids.Any(e => e.LiquidsId == id);
        }
    }
}