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
    public class IndexModel : PageModel
    {
        private readonly VendorConnect.Data.AppDbContext _context;

        public IndexModel(VendorConnect.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Vendor> Vendor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Vendor = await _context.Vendors.ToListAsync();
        }
    }
}
