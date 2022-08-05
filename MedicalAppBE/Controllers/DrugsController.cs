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
    public class DrugsController : ControllerBase
    {
        private readonly DataContext _context;

        public DrugsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrugs()
        {
            return await _context.Drugs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrug(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null)
                return NotFound();

            return drug;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDrug(int id, Drug drug)
        {
            if (id != drug.DrugId)
                return BadRequest();

            _context.Entry(drug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Drug>> AddDrug(Drug drug)
        {
            _context.Drugs.Add(drug);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDrug", new { id = drug.DrugId }, drug);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDrug(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            _context.Drugs.Remove(drug);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrugExists(int id)
        {
            return _context.Drugs.Any(e => e.DrugId == id);
        }
    }
}