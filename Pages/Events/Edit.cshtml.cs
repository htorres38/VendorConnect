using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendorConnect.Data;
using VendorConnect.Models;
using System.Linq;
using System.Threading.Tasks;

namespace VendorConnect.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public SelectList VendorList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Event = await _context.Events
                                  .Include(e => e.Vendor)
                                  .FirstOrDefaultAsync(m => m.ID == id);

            if (Event == null)
                return NotFound();

            VendorList = new SelectList(_context.Vendors, "ID", "BusinessName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                VendorList = new SelectList(_context.Vendors, "ID", "BusinessName");
                return Page();
            }

            _context.Attach(Event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Events.Any(e => e.ID == Event.ID))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
