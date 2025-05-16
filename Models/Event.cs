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
        [FutureDate(ErrorMessage = "Event date must be in the future.")]
        public DateTime EventDate { get; set; }

        [Required]
        public int VendorID { get; set; }

        public Vendor Vendor { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }
}

