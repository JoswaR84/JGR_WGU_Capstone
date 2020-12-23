using JGR_WGU_Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JGR_WGU_Capstone.Pages.Maintenances
{
    public class DeleteModel : PageModel
    {
        private readonly JGR_WGU_Capstone.Data.ApplicationDbContext _context;

        public DeleteModel(JGR_WGU_Capstone.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Maintenance = await _context.Maintenance.FindAsync(id);

            if (Maintenance != null)
            {
                _context.Maintenance.Remove(Maintenance);
                await _context.SaveChangesAsync();
            }

            var URL = "/Computers/Details?id=" + Maintenance.ComputerID;
            return Redirect(URL);
        }
    }
}
