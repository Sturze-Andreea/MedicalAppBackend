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
    public class AnamnesisController : ControllerBase
    {
        private readonly DataContext _context;

        public AnamnesisController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anamnesis>>> GetAnamnesiss()
        {
            return await _context.Anamnesiss.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Anamnesis>> GetAnamnesis(int id)
        {
            var anamnesis = await _context.Anamnesiss.FindAsync(id);
            if (anamnesis == null)
                return NotFound();

            return anamnesis;
        }

        [HttpGet("hospitalization/{id}")]
        public async Task<ActionResult<Anamnesis>> GetAnamnesisByHospitalization(int id)
        {
            var anamnesis = await _context.Anamnesiss.FirstOrDefaultAsync((anamnesis)=> anamnesis.HospitalizationId == id);
            if (anamnesis == null)
                return NotFound();

            return anamnesis;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAnamnesis(int id, Anamnesis anamnesis)
        {
            if (id != anamnesis.AnamnesisId)
                return BadRequest();

            _context.Entry(anamnesis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnamnesisExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Anamnesis>> AddAnamnesis(Anamnesis anamnesis)
        {
            _context.Anamnesiss.Add(anamnesis);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAnamnesis", new { id = anamnesis.AnamnesisId }, anamnesis);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnamnesis(int id)
        {
            var anamnesis = await _context.Anamnesiss.FindAsync(id);
            if (anamnesis == null)
            {
                return NotFound();
            }
            _context.Anamnesiss.Remove(anamnesis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnamnesisExists(int id)
        {
            return _context.Anamnesiss.Any(e => e.AnamnesisId == id);
        }
    }
}