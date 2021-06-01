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
    public class DocDetailsController : ControllerBase
    {
        private readonly ClinicalDetailsContext _context;

        public DocDetailsController(ClinicalDetailsContext context)
        {
            _context = context;
        }

        // GET: api/DocDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocDetails>>> GetDocTable()
        {
            return await _context.DocTable.ToListAsync();
        }

        // GET: api/DocDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocDetails>> GetDocDetails(int id)
        {
            var docDetails = await _context.DocTable.FindAsync(id);

            if (docDetails == null)
            {
                return NotFound();
            }

            return docDetails;
        }

        // PUT: api/DocDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocDetails(int id, DocDetails docDetails)
        {
            if (id != docDetails.DoctorID)
            {
                return BadRequest();
            }

            _context.Entry(docDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocDetailsExists(id))
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

        // POST: api/DocDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocDetails>> PostDocDetails(DocDetails docDetails)
        {
            _context.DocTable.Add(docDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocDetails", new { id = docDetails.DoctorID }, docDetails);
        }

        // DELETE: api/DocDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocDetails(int id)
        {
            var docDetails = await _context.DocTable.FindAsync(id);
            if (docDetails == null)
            {
                return NotFound();
            }

            _context.DocTable.Remove(docDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocDetailsExists(int id)
        {
            return _context.DocTable.Any(e => e.DoctorID == id);
        }
    }
}
