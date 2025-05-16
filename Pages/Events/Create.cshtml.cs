using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VendorConnect.Data;
using VendorConnect.Models;
using System.Threading.Tasks;

namespace VendorConnect.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public SelectList VendorList { get; set; }

        public void OnGet()
        {
            VendorList = new SelectList(_context.Vendors, "ID", "BusinessName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                VendorList = new SelectList(_context.Vendors, "ID", "BusinessName");
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
