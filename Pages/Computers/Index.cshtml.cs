using JGR_WGU_Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JGR_WGU_Capstone.Pages.Computers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public readonly JGR_WGU_Capstone.Data.ApplicationDbContext _context;

        public IndexModel(JGR_WGU_Capstone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Computer> Computer { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }        

        public async Task OnGetAsync()
        {
            var computers = from c in _context.Computer select c;

            if (!string.IsNullOrEmpty(SearchString))
            {
                computers = computers.Where(s => s.SerialNumber.Contains(SearchString) || s.Manufacturer.Contains(SearchString) || s.Model.Contains(SearchString));
            }

            Computer = await computers.ToListAsync();
        }
    }
}
