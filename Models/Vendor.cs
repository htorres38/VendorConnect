using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendorConnect.Models
{
    public class Vendor
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string BusinessName { get; set; }

        [Required]
        public string Specialty { get; set; }

        public List<Event> Events { get; set; }
    }
}
