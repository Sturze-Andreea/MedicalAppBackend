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
    public class ClinicalExaminationController : ControllerBase
    {
        private readonly DataContext _context;

        public ClinicalExaminationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClinicalExamination>>> GetClinicalExaminations()
        {
            return await _context.ClinicalExaminations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClinicalExamination>> GetClinicalExamination(int id)
        {
            var clinicalExamination = await _context.ClinicalExaminations.FindAsync(id);
            if (clinicalExamination == null)
                return NotFound();

            return clinicalExamination;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClinicalExamination(int id, ClinicalExamination clinicalExamination)
        {
            if (id != clinicalExamination.ClinicalExaminationId)
                return BadRequest();

            _context.Entry(clinicalExamination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicalExaminationExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ClinicalExamination>> AddClinicalExamination(ClinicalExamination clinicalExamination)
        {
            _context.ClinicalExaminations.Add(clinicalExamination);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetClinicalExamination", new { id = clinicalExamination.ClinicalExaminationId }, clinicalExamination);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClinicalExamination(int id)
        {
            var clinicalExamination = await _context.ClinicalExaminations.FindAsync(id);
            if (clinicalExamination == null)
            {
                return NotFound();
            }
            _context.ClinicalExaminations.Remove(clinicalExamination);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClinicalExaminationExists(int id)
        {
            return _context.ClinicalExaminations.Any(e => e.ClinicalExaminationId == id);
        }
    }
}