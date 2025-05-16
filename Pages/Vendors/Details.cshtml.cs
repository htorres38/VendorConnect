using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VendorConnect.Data;
using VendorConnect.Models;

namespace VendorConnect.Pages_Vendors
{
    public class DetailsModel : PageModel
    {
        private readonly VendorConnect.Data.AppDbContext _context;

        public DetailsModel(VendorConnect.Data.AppDbContext context)
        {
            _context = context;
        }

        public Vendor Vendor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendors.FirstOrDefaultAsync(m => m.ID == id);

            if (vendor is not null)
            {
                Vendor = vendor;

                return Page();
            }

            return NotFound();
        }
    }
}
