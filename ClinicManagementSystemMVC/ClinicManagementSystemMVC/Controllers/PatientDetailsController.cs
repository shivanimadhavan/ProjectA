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
    public class PatientDetailsController : Controller
    {
        private readonly ClinicalDetailsContext _context;

        public PatientDetailsController(ClinicalDetailsContext context)
        {
            _context = context;
        }

        // GET: PatientDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientTable.ToListAsync());
        }

        // GET: PatientDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetails = await _context.PatientTable
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patientDetails == null)
            {
                return NotFound();
            }

            return View(patientDetails);
        }

        // GET: PatientDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientID,FirstName,LastName,Sex,Age,Date_of_Birth,PhoneNumber")] PatientDetails patientDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientDetails);
        }

        // GET: PatientDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetails = await _context.PatientTable.FindAsync(id);
            if (patientDetails == null)
            {
                return NotFound();
            }
            return View(patientDetails);
        }

        // POST: PatientDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientID,FirstName,LastName,Sex,Age,Date_of_Birth,PhoneNumber")] PatientDetails patientDetails)
        {
            if (id != patientDetails.PatientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientDetailsExists(patientDetails.PatientID))
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
            return View(patientDetails);
        }

        // GET: PatientDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetails = await _context.PatientTable
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patientDetails == null)
            {
                return NotFound();
            }

            return View(patientDetails);
        }

        // POST: PatientDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientDetails = await _context.PatientTable.FindAsync(id);
            _context.PatientTable.Remove(patientDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientDetailsExists(int id)
        {
            return _context.PatientTable.Any(e => e.PatientID == id);
        }
    }
}
