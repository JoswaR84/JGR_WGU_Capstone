using JGR_WGU_Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public SelectList Makes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CompMake { get; set; }
        public SelectList Models { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CompModel { get; set; }
        [ViewData]
        public string CurrentDate { get; set; }
        public IList<Computer> Computer { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> makeQuery = from c in _context.Computer orderby c.Manufacturer select c.Manufacturer;
            IQueryable<string> modelQuery = from c in _context.Computer orderby c.Model select c.Model;

            var computers = from c in _context.Computer select c;

            if (!string.IsNullOrEmpty(CompMake))
            {
                computers = computers.Where(x => x.Manufacturer == CompMake);
            }

            if (!string.IsNullOrEmpty(CompModel))
            {
                computers = computers.Where(x => x.Model == CompModel);
            }

            Makes = new SelectList(await makeQuery.Distinct().ToListAsync());
            Models = new SelectList(await modelQuery.Distinct().ToListAsync());

            var TodayDateTime = DateTime.Today;
            CurrentDate = TodayDateTime.ToShortDateString();
            Computer = await computers.ToListAsync();
        }
    }
}
