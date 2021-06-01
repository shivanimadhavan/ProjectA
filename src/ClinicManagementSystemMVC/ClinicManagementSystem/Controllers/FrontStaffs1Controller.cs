using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Controllers
{
    public class FrontStaffs1Controller : Controller
    {
        private readonly ClinicalDetailsContext _context;

        public FrontStaffs1Controller(ClinicalDetailsContext context)
        {
            _context = context;
        }

        // GET: FrontStaffs1
        public async Task<IActionResult> Index()
        {
            return View(await _context.FrontStaffTable.ToListAsync());
        }

        // GET: FrontStaffs1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frontStaff = await _context.FrontStaffTable
                .FirstOrDefaultAsync(m => m.StaffUsername == id);
            if (frontStaff == null)
            {
                return NotFound();
            }

            return View(frontStaff);
        }

        // GET: FrontStaffs1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FrontStaffs1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffUsername,Password")] FrontStaff frontStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frontStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frontStaff);
        }

        // GET: FrontStaffs1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frontStaff = await _context.FrontStaffTable.FindAsync(id);
            if (frontStaff == null)
            {
                return NotFound();
            }
            return View(frontStaff);
        }

        // POST: FrontStaffs1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StaffUsername,Password")] FrontStaff frontStaff)
        {
            if (id != frontStaff.StaffUsername)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frontStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrontStaffExists(frontStaff.StaffUsername))
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
            return View(frontStaff);
        }

        // GET: FrontStaffs1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frontStaff = await _context.FrontStaffTable
                .FirstOrDefaultAsync(m => m.StaffUsername == id);
            if (frontStaff == null)
            {
                return NotFound();
            }

            return View(frontStaff);
        }

        // POST: FrontStaffs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var frontStaff = await _context.FrontStaffTable.FindAsync(id);
            _context.FrontStaffTable.Remove(frontStaff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrontStaffExists(string id)
        {
            return _context.FrontStaffTable.Any(e => e.StaffUsername == id);
        }
    }
}
