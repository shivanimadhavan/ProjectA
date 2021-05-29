using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagementSystemMVC.Models;

namespace ClinicManagementSystemMVC.Controllers
{
    public class DocDetailsController : Controller
    {
        private readonly ClinicalDetailsContext _context;

        public DocDetailsController(ClinicalDetailsContext context)
        {
            _context = context;
        }

        // GET: DocDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.DocTable.ToListAsync());
        }

        // GET: DocDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docDetails = await _context.DocTable
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (docDetails == null)
            {
                return NotFound();
            }

            return View(docDetails);
        }

        // GET: DocDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorID,FirstName,LastName,Sex,Age,Date_of_Birth,Specialization,FromTime,ToTime,PhoneNumber")] DocDetails docDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docDetails);
        }

        // GET: DocDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docDetails = await _context.DocTable.FindAsync(id);
            if (docDetails == null)
            {
                return NotFound();
            }
            return View(docDetails);
        }

        // POST: DocDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorID,FirstName,LastName,Sex,Age,Date_of_Birth,Specialization,FromTime,ToTime,PhoneNumber")] DocDetails docDetails)
        {
            if (id != docDetails.DoctorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocDetailsExists(docDetails.DoctorID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(docDetails);
        }

        // GET: DocDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docDetails = await _context.DocTable
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (docDetails == null)
            {
                return NotFound();
            }

            return View(docDetails);
        }

        // POST: DocDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docDetails = await _context.DocTable.FindAsync(id);
            _context.DocTable.Remove(docDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocDetailsExists(int id)
        {
            return _context.DocTable.Any(e => e.DoctorID == id);
        }
    }
}
