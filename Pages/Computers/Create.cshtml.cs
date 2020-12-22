using JGR_WGU_Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace JGR_WGU_Capstone.Pages.Computers
{
    public class CreateModel : PageModel
    {
        private readonly JGR_WGU_Capstone.Data.ApplicationDbContext _context;

        public CreateModel(JGR_WGU_Capstone.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Computer Computer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Computer.Add(Computer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
