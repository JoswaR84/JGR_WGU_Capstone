using JGR_WGU_Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Threading.Tasks;

namespace JGR_WGU_Capstone.Pages.Maintenances
{
    public class CreateModel : PageModel
    {
        private readonly JGR_WGU_Capstone.Data.ApplicationDbContext _context;

        public CreateModel(JGR_WGU_Capstone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [ViewData]
        public int PassedComputerID { get; set; }

        public IActionResult OnGet(int compid)
        {
            PassedComputerID = compid;
            Debug.Write(PassedComputerID);
            return Page();
        }

        [BindProperty]
        public Maintenance Maintenance { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Maintenance.Add(Maintenance);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Computers/Index");
        }
    }
}

