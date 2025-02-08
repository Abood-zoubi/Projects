using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFCodeFirst.Entities
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        [MaxLength(20)]
        public required string PaymentMethodName { get; set; }
        public ICollection<Vendor>? Vendors { get; set; }
    }
}
