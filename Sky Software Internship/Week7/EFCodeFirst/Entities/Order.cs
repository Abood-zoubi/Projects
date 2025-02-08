using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EFCodeFirst.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int VendorId { get; set; }
        
        [Required]
        public DateOnly OrderDate { get; set; }
        public DateOnly? DeliveryDate { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }
        public Vendor? Vendor { get; set; } 
        public ICollection<OrderItem>? OrderItems { get; set; }

        public Order(int vendorId, DateOnly orderDate, DateOnly? deliveryDate, string? description)
        {
            VendorId = vendorId;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            Description = description;
        }
    }
}
