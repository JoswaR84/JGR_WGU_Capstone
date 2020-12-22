using JGR_WGU_Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JGR_WGU_Capstone.Pages.Computers
{
    public class DetailsModel : PageModel
    {
        private readonly JGR_WGU_Capstone.Data.ApplicationDbContext _context;

        public DetailsModel(JGR_WGU_Capstone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Computer Computer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Computer = await _context.Computer
                .Include(s => s.Maintenances)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ComputerID == id);

            if (Computer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
