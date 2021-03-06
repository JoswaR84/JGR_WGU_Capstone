﻿using JGR_WGU_Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JGR_WGU_Capstone.Pages.Maintenances
{
    public class EditModel : PageModel
    {
        private readonly JGR_WGU_Capstone.Data.ApplicationDbContext _context;

        public EditModel(JGR_WGU_Capstone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Maintenance Maintenance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Maintenance = await _context.Maintenance
                .Include(m => m.Computer).FirstOrDefaultAsync(m => m.MaintenanceID == id);

            if (Maintenance == null)
            {
                return NotFound();
            }
           ViewData["ComputerID"] = new SelectList(_context.Computer, "ComputerID", "Manufacturer");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Maintenance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceExists(Maintenance.MaintenanceID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var URL = "/Computers/Details?id=" + Maintenance.ComputerID;
            return Redirect(URL);
        }

        private bool MaintenanceExists(int id)
        {
            return _context.Maintenance.Any(e => e.MaintenanceID == id);
        }
    }
}
