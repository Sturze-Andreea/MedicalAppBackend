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
    public class IngestedFluidsController : ControllerBase
    {
        private readonly DataContext _context;

        public IngestedFluidsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngestedFluid>>> GetIngestedFluids()
        {
            return await _context.IngestedFluids.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngestedFluid>> GetIngestedFluid(int id)
        {
            var ingestedFluid = await _context.IngestedFluids.FindAsync(id);
            if (ingestedFluid == null)
                return NotFound();

            return ingestedFluid;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIngestedFluid(int id, IngestedFluid ingestedFluid)
        {
            if (id != ingestedFluid.IngestedFluidId)
                return BadRequest();

            _context.Entry(ingestedFluid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngestedFluidExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<IngestedFluid>> AddIngestedFluid(IngestedFluid ingestedFluid)
        {
            _context.IngestedFluids.Add(ingestedFluid);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetIngestedFluid", new { id = ingestedFluid.IngestedFluidId }, ingestedFluid);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIngestedFluid(int id)
        {
            var ingestedFluid = await _context.IngestedFluids.FindAsync(id);
            if (ingestedFluid == null)
            {
                return NotFound();
            }
            _context.IngestedFluids.Remove(ingestedFluid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngestedFluidExists(int id)
        {
            return _context.IngestedFluids.Any(e => e.IngestedFluidId == id);
        }
    }
}