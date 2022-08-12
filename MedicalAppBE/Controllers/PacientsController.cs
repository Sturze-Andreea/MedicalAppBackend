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
    public class PatientsController : ControllerBase
    {

        private readonly DataContext _context;

        public PatientsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return NotFound();

            return patient;
        }

        [HttpGet("fromWard/{id}")]
        public async Task<ActionResult<Patient>> GetPatientsFromWard(int id)
        {
            var patients = await _context.Patients
                .Join(
                    _context.Hospitalizations,
                    patient => patient.PatientId,
                    hospitalization => hospitalization.PatientId,
                    (patient, hospitalization) => new PatientFromWard
                    {
                        PatientId = patient.PatientId,
                        HospitalizationId = hospitalization.HospitalizationId,
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        CNP = patient.CNP,
                        DOB = patient.DOB,
                        WardId = hospitalization.WardId,
                        HospitalizationDate = hospitalization.Date,
                        Doctor = hospitalization.Doctor,
                        Discharged = hospitalization.Discharged,
                        RoomNr = hospitalization.RoomNr,
                        BedNr = hospitalization.BedNr
                    }
                ).Where(pacientFromWard => pacientFromWard.WardId == id && pacientFromWard.Discharged == false).ToListAsync();
            
            return Ok(patients);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, Patient patient)
        {
                patient.PatientId = id;

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPatient", new { id = patient.PatientId }, patient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }
    }
}