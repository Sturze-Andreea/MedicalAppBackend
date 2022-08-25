using System.Collections.Generic;
using System;
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
        [HttpGet("chart/{id}")]
        public async Task<ActionResult<IEnumerable<ChartData>>> GetHospitalizationChartData(int id)
        {
            var temp = await _context.Temperatures.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).ToListAsync();
            var pulse = await _context.Pulses.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).ToListAsync();
            var ta = await _context.TAs.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).ToListAsync();
            var breath = await _context.Breaths.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).ToListAsync();

            var dates = temp.Select(elem => elem.Date).ToArray();
            dates = dates.Union(pulse.Select(elem => elem.Date).ToArray()).ToArray();
            dates = dates.Union(ta.Select(elem => elem.Date).ToArray()).ToArray();
            dates = dates.Union(breath.Select(elem => elem.Date).ToArray()).OrderBy((elem) => elem).ToArray();
            var data = new List<ChartData>();
            foreach (var date in dates)
            {
                var chartdata = new ChartData();
                chartdata.HospitalizationId = id;
                chartdata.Date = date;
                var br = breath.Where((elem) => elem.Date == date).FirstOrDefault();
                if (br != null)
                {
                    chartdata.BreathNr = br.BreathNr;
                }
                else { chartdata.BreathNr = -1; }
                var puls = pulse.Where((elem) => elem.Date == date).FirstOrDefault();
                if (puls != null)
                {
                    chartdata.Pulse = puls.Puls;
                }
                else { chartdata.Pulse = -1; }
                var tmp = temp.Where((elem) => elem.Date == date).FirstOrDefault();
                if (tmp != null)
                {
                    chartdata.Temperature = tmp.Temp;
                }
                else { chartdata.Temperature = -1; }
                var oneTA = ta.Where((elem) => elem.Date == date).FirstOrDefault();
                if (oneTA != null)
                {
                    chartdata.MaxTA = oneTA.Max;
                    chartdata.MinTA = oneTA.Min;
                }
                else
                {
                    chartdata.MaxTA = -1;
                    chartdata.MinTA = -1;
                }
                data.Add(chartdata);

            }


            return data;
        }


        [HttpGet("details/{id}")]
        public async Task<ActionResult<Details>> GetHospitalizationDetails(int id)
        {
            var temp = await _context.Temperatures.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).LastOrDefaultAsync();
            var pulse = await _context.Pulses.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).LastOrDefaultAsync();
            var ta = await _context.TAs.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).LastOrDefaultAsync();
            var breath = await _context.Breaths.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).LastOrDefaultAsync();
            var liquids = await _context.Liquids.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).LastOrDefaultAsync();
            var evolution = await _context.Evolutions.Where((elem) => elem.HospitalizationId == id).OrderBy((elem) => elem.Date).LastOrDefaultAsync();
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
            if (liquids != null)
            {
                details.VomitingDescription = liquids.Vomiting;
                details.DiuresisDescription = liquids.Diuresis;
                details.DischargeDescription = liquids.Discharge;
            }
            if (evolution != null)
            {
                details.EvolutionDescription = evolution.Description;
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