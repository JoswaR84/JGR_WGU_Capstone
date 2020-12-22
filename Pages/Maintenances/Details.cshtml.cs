﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JGR_WGU_Capstone.Data;
using JGR_WGU_Capstone.Models;

namespace JGR_WGU_Capstone.Pages.Maintenances
{
    public class DetailsModel : PageModel
    {
        private readonly JGR_WGU_Capstone.Data.ApplicationDbContext _context;

        public DetailsModel(JGR_WGU_Capstone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}