using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomePageDetails.Models;

namespace HomePageDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : ControllerBase
    {
        private readonly ClinicalDetailsContext _context;

        public PatientDetailsController(ClinicalDetailsContext context)
        {
            _context = context;
        }

        // GET: api/PatientDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDetails>>> GetPatientTable()
        {
            return await _context.PatientTable.ToListAsync();
        }

        // GET: api/PatientDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetails>> GetPatientDetails(int id)
        {
            var patientDetails = await _context.PatientTable.FindAsync(id);

            if (patientDetails == null)
            {
                return NotFound();
            }

            return patientDetails;
        }

        // PUT: api/PatientDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientDetails(int id, PatientDetails patientDetails)
        {
            if (id != patientDetails.PatientID)
            {
                return BadRequest();
            }

            _context.Entry(patientDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PatientDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientDetails>> PostPatientDetails(PatientDetails patientDetails)
        {
            _context.PatientTable.Add(patientDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientDetails", new { id = patientDetails.PatientID }, patientDetails);
        }

        // DELETE: api/PatientDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientDetails(int id)
        {
            var patientDetails = await _context.PatientTable.FindAsync(id);
            if (patientDetails == null)
            {
                return NotFound();
            }

            _context.PatientTable.Remove(patientDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientDetailsExists(int id)
        {
            return _context.PatientTable.Any(e => e.PatientID == id);
        }
    }
}
