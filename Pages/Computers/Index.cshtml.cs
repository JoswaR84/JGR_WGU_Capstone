﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JGR_WGU_Capstone.Data;
using JGR_WGU_Capstone.Models;

namespace JGR_WGU_Capstone.Pages.Computers
{
    public class IndexModel : PageModel
    {
        private readonly JGR_WGU_Capstone.Data.ApplicationDbContext _context;

        public IndexModel(JGR_WGU_Capstone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Computer> Computer { get;set; }

        public async Task OnGetAsync()
        {
            Computer = await _context.Computer.ToListAsync();
        }
    }
}
