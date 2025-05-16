using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using VendorConnect.Models;

namespace VendorConnect.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Vendors.Any())
            {
                return;   
            }

            var vendors = new Vendor[]
            {
                new Vendor { BusinessName = "Sunshine Weddings", Specialty = "Photography" },
                new Vendor { BusinessName = "Bloom Floral", Specialty = "Florist" },
                new Vendor { BusinessName = "Gourmet Catering", Specialty = "Catering" },
                new Vendor { BusinessName = "DJ MixMaster", Specialty = "DJ & Music" },
                new Vendor { BusinessName = "Elegant Venues", Specialty = "Venue Rental" }
            };

            context.Vendors.AddRange(vendors);
            context.SaveChanges();

            var random = new Random();
            var events = Enumerable.Range(1, 25).Select(i =>
                new Event
                {
                    CoupleNames = $"Couple {i}",
                    EventDate = DateTime.Now.AddDays(random.Next(30, 365)), 
                    VendorID = vendors[random.Next(vendors.Length)].ID
                }).ToArray();

            context.Events.AddRange(events);
            context.SaveChanges();
        }
    }
}
