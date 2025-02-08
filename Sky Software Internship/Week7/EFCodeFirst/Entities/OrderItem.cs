using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Entities
{
    public class OrderItem
    {
        [Key]
        public int ItemId { get; set; }
        public int OrderId { get; set; }

        [Required, MaxLength(10)]
        public string ItemCode { get; set; }
        [Required, MaxLength(50)]
        public string ItemName { get; set; }
        [Required, MaxLength(50)]
        public string Unit { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal CostAmount { get; set; }
        public Order? Order { get; set; }

        public OrderItem(int orderId, string itemCode, string itemName, string unit, decimal quantity, decimal price, decimal costAmount)
        {
            OrderId = orderId;
            ItemCode = itemCode;
            ItemName = itemName;
            Unit = unit;
            Quantity = quantity;
            Price = price;
            CostAmount = costAmount;
        }
    }
}
