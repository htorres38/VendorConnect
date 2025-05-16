using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendorConnect.Models
{
    public class Event
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CoupleNames { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required]
        public int VendorID { get; set; }

        public Vendor Vendor { get; set; }
    }
}
