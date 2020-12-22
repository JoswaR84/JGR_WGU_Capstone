using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JGR_WGU_Capstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace JGR_WGU_Capstone.Pages.Computers
{
    [Authorize]
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
