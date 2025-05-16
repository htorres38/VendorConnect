using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VendorConnect.Data;
using VendorConnect.Models;
using System.Threading.Tasks;

namespace VendorConnect.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Event = await _context.Events
                .Include(e => e.Vendor)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Event == null)
                return NotFound();

            return Page();
        }
    }
}
