using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VendorConnect.Data;
using VendorConnect.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace VendorConnect.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get; set; }

        public string CoupleSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }
        public string SearchString { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            CoupleSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            CurrentSort = sortOrder;
            SearchString = searchString;

            var events = from e in _context.Events.Include(e => e.Vendor)
                         select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                events = events.Where(e => e.CoupleNames.Contains(searchString));
            }

            events = sortOrder switch
            {
                "name_desc" => events.OrderByDescending(e => e.CoupleNames),
                "Date" => events.OrderBy(e => e.EventDate),
                "date_desc" => events.OrderByDescending(e => e.EventDate),
                _ => events.OrderBy(e => e.CoupleNames),
            };

            Events = await events.AsNoTracking().ToListAsync();
        }
    }
}
