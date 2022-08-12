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
    public class HospitalizationsController : ControllerBase
    {

        private readonly DataContext _context;

        public HospitalizationsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospitalization>>> GetHospitalizations()
        {
            return await _context.Hospitalizations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hospitalization>> GetHospitalization(int id)
        {
            var hospitalization = await _context.Hospitalizations.FindAsync(id);
            if (hospitalization == null)
                return NotFound();

            return hospitalization;
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<Details>> GetHospitalizationDetails(int id)
        {
            var temp = await _context.Temperatures.Where((temp) => temp.HospitalizationId == id).OrderBy((temp) => temp.Date).LastOrDefaultAsync();
            var pulse = await _context.Pulses.Where((temp) => temp.HospitalizationId == id).OrderBy((temp) => temp.Date).LastOrDefaultAsync();
            var ta = await _context.TAs.Where((temp) => temp.HospitalizationId == id).OrderBy((temp) => temp.Date).LastOrDefaultAsync();
            var breath = await _context.Breaths.Where((temp) => temp.HospitalizationId == id).OrderBy((temp) => temp.Date).LastOrDefaultAsync();
            var discharge = await _context.Discharges.Where((temp) => temp.HospitalizationId == id).OrderBy((temp) => temp.Date).LastOrDefaultAsync();
            var diuresis = await _context.Diuresises.Where((temp) => temp.HospitalizationId == id).OrderBy((temp) => temp.Date).LastOrDefaultAsync();
            var fluids = await _context.IngestedFluids.Where((temp) => temp.HospitalizationId == id).OrderBy((temp) => temp.Date).LastOrDefaultAsync();
            var vomit = await _context.Vomitings.Where((temp) => temp.HospitalizationId == id).OrderBy((temp) => temp.Date).LastOrDefaultAsync();
            var details = new Details();
            details.HospitalizationId = id;
            if (temp != null)
            {
                details.Temperature = temp.Temp;
            }
            else
            {
                details.Temperature = -1;
            }
            if (pulse != null)
            {
                details.Pulse = pulse.Puls;
            }
            else
            {
                details.Pulse = -1;
            }
            if (ta != null)
            {
                details.MinTA = ta.Min;
                details.MaxTA = ta.Max;
            }
            else
            {
                details.MinTA = -1;
                details.MaxTA = -1;
            }
            if (breath != null)
            {
                details.BreathNr = breath.BreathNr;
            }
            else
            {
                details.BreathNr = -1;
            }
            if (discharge != null)
            {
                details.DischargeDescription = discharge.Description;
            }
            if (diuresis != null)
            {
                details.DiuresisDescription = diuresis.Description;
            }
            if (fluids != null)
            {
                details.Fluid = fluids.Fluid;
            }
            else
            {
                details.Fluid = -1;
            }
            if (vomit != null)
            {
                details.VomitingDescription = vomit.Description;
            }

            return details;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHospitalization(int id, Hospitalization hospitalization)
        {
            if (id != hospitalization.HospitalizationId)
                return BadRequest();

            _context.Entry(hospitalization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalizationExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Hospitalization>> AddHospitalization(Hospitalization hospitalization)
        {
            _context.Hospitalizations.Add(hospitalization);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHospitalization", new { id = hospitalization.HospitalizationId }, hospitalization);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHospitalization(int id)
        {
            var hospitalization = await _context.Hospitalizations.FindAsync(id);
            if (hospitalization == null)
            {
                return NotFound();
            }
            _context.Hospitalizations.Remove(hospitalization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalizationExists(int id)
        {
            return _context.Hospitalizations.Any(e => e.HospitalizationId == id);
        }
    }
}