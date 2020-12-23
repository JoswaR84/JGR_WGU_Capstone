using JGR_WGU_Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JGR_WGU_Capstone.Pages.Reports
{
    [Authorize]
    public class ComputerReportModel : PageModel
    {
        private readonly JGR_WGU_Capstone.Data.ApplicationDbContext _context;

        public ComputerReportModel(JGR_WGU_Capstone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [ViewData]
        public string CurrentDate { get; set; }

        public IList<Computer> Computer { get;set; }

        public async Task OnGetAsync()
        {            
            var TodayDateTime = DateTime.Today;            
            CurrentDate = TodayDateTime.ToShortDateString();
            Computer = await _context.Computer.ToListAsync();
        }
    }
}
