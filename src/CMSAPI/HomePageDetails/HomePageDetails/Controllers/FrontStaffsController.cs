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
    public class FrontStaffsController : ControllerBase
    {
        private readonly ClinicalDetailsContext _context;

        public FrontStaffsController(ClinicalDetailsContext context)
        {
            _context = context;
        }

        // GET: api/FrontStaffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrontStaff>>> GetFrontStaffTable()
        {
            return await _context.FrontStaffTable.ToListAsync();
        }

        // GET: api/FrontStaffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FrontStaff>> GetFrontStaff(string id)
        {
            var frontStaff = await _context.FrontStaffTable.FindAsync(id);

            if (frontStaff == null)
            {
                return NotFound();
            }

            return frontStaff;
        }

        // PUT: api/FrontStaffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrontStaff(string id, FrontStaff frontStaff)
        {
            if (id != frontStaff.StaffUsername)
            {
                return BadRequest();
            }

            _context.Entry(frontStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrontStaffExists(id))
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

        // POST: api/FrontStaffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FrontStaff>> PostFrontStaff(FrontStaff frontStaff)
        {
            _context.FrontStaffTable.Add(frontStaff);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FrontStaffExists(frontStaff.StaffUsername))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFrontStaff", new { id = frontStaff.StaffUsername }, frontStaff);
        }

        // DELETE: api/FrontStaffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrontStaff(string id)
        {
            var frontStaff = await _context.FrontStaffTable.FindAsync(id);
            if (frontStaff == null)
            {
                return NotFound();
            }

            _context.FrontStaffTable.Remove(frontStaff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FrontStaffExists(string id)
        {
            return _context.FrontStaffTable.Any(e => e.StaffUsername == id);
        }
    }
}
