using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Entities
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }
        [MaxLength(60)]
        public required string VendorName { get; set; }
        [MaxLength(40)]
        public required string Email { get; set; }
        [MaxLength(200)]
        public string? VendorAddress { get; set; }
        public int PaymentMethodId { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public Vendor(string vendorName, string email, string vendorAddress, int paymentMehtodId)
        {
            VendorName = vendorName;
            Email = email;
            VendorAddress = vendorAddress;
            PaymentMethodId = paymentMehtodId;
        }
        public Vendor() { }
    }
}
