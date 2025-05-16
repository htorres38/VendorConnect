using Microsoft.AspNetCore.Mvc.RazorPages;
using VendorConnect.Data;

namespace VendorConnect.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public int VendorCount { get; set; }
        public int EventCount { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            VendorCount = _context.Vendors.Count();
            EventCount = _context.Events.Count();
        }
    }
}