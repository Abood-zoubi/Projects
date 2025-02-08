using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirst.Entities;

namespace EFCodeFirst
{
    internal class Program
    {
        static void Main()
        {
            using var dbContext = new EFCoreDbContext();
            SeedData(dbContext);

            while (true)
            {
                Console.WriteLine("\n----- Purchasing System Menu -----");
                Console.WriteLine("1. Place New Order");
                Console.WriteLine("2. Add Item to Order");
                Console.WriteLine("3. Remove Item from Order");
                Console.WriteLine("4. Update Order Item Quantity & Price");
                Console.WriteLine("5. Update Vendor Information");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddOrder(dbContext);
                        break;
                    case "2":
                        AddItem(dbContext);
                        break;
                    case "3":
                        RemoveItem(dbContext);
                        break;
                    case "4":
                        UpdateOrder(dbContext);
                        break;
                    case "5":
                        UpdateVendor(dbContext);
                        break;
                    case "6":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }


        private static void AddOrder(EFCoreDbContext dbContext)
        {
            Console.Write("Enter Vendor ID: ");
            int vendorId = int.Parse(Console.ReadLine());

            Console.Write("Enter Order Year: ");
            int OrderYear = int.Parse(Console.ReadLine());

            Console.Write("Enter Order month: ");
            int OrderMonth = int.Parse(Console.ReadLine());

            Console.Write("Enter Order Day: ");
            int OrderDay = int.Parse(Console.ReadLine());

            var OrderDate = new DateOnly(OrderYear, OrderMonth, OrderDay);

            Console.Write("Enter Delivery Year: ");
            int DeliveryYear = int.Parse(Console.ReadLine());

            Console.Write("Enter Delivery month: ");
            int DeliveryMonth = int.Parse(Console.ReadLine());

            Console.Write("Enter Delivery Day: ");
            int DeliveryDay = int.Parse(Console.ReadLine());

            var DeliveryDate = new DateOnly(DeliveryYear, DeliveryMonth, DeliveryDay);

            Console.Write("Enter Order Description: ");
            string description = Console.ReadLine() ?? string.Empty;

            var NewOrder = new Order(vendorId, OrderDate, DeliveryDate, description);
            dbContext.Orders.Add(NewOrder);
            dbContext.SaveChanges();
            Console.WriteLine("Order placed successfully!");
        }

        private static void AddItem(EFCoreDbContext dbContext)
        {
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());

            Console.Write("Enter Item Code: ");
            string itemCode = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Item Name: ");
            string itemName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Unit: ");
            string unit = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Quantity: ");
            decimal quantity = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            decimal costPrice = quantity * price;
             
            var orderItem = new OrderItem(orderId, itemCode, itemName, unit, quantity, price, costPrice);
            dbContext.OrderItems.Add(orderItem);
            dbContext.SaveChanges();
        }

        private static void RemoveItem(EFCoreDbContext dbContext)
        {
            Console.Write("Enter Item ID to remove: ");
            int itemId = int.Parse(Console.ReadLine());

            var orderItem = dbContext.OrderItems.Where(oi => oi.ItemId == itemId).FirstOrDefault();
            if (orderItem != null)
            {
                dbContext.OrderItems.Remove(orderItem);
                dbContext.SaveChanges();
                Console.WriteLine("Item removed successfully!");
            }
            else
            {
                Console.WriteLine("Item was not found");
            }
        }

        private static void UpdateOrder(EFCoreDbContext dbContext)
        {
            Console.Write("Enter Item ID to Update: ");
            int itemId = int.Parse(Console.ReadLine());

            var orderItem = dbContext.OrderItems.Where(oi => oi.ItemId == itemId).FirstOrDefault();
            if (orderItem != null)
            {
                Console.Write("Enter new Quantity: ");
                orderItem.Quantity = decimal.Parse(s: Console.ReadLine());

                Console.Write("Enter new Price: ");
                orderItem.Price = decimal.Parse(Console.ReadLine());

                orderItem.CostAmount = orderItem.Quantity * orderItem.Price;

                dbContext.SaveChanges();
                Console.WriteLine("Order item updated successfully!");
            }
            else
            {
                Console.WriteLine("Item not found!");
            }
        }

        private static void UpdateVendor(EFCoreDbContext dbContext)
        {
            Console.Write("Enter Vendor ID to update: ");
            int vendorId = int.Parse(Console.ReadLine());

            var vendor = dbContext.Vendors.Where(v => v.VendorId == vendorId).FirstOrDefault();
            if (vendor != null)
            {
                Console.Write("Enter new Email: ");
                vendor.Email = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter new Vendor Address: ");
                vendor.VendorAddress = Console.ReadLine();

                Console.Write("Enter new Payment Method ID: ");
                vendor.PaymentMethodId = int.Parse(Console.ReadLine());

                dbContext.SaveChanges();
                Console.WriteLine("Vendor information updated successfully!");
            }
            else
            {
                Console.WriteLine("Vendor not found!");
            }
        }

        private static void SeedData(EFCoreDbContext dbContext)
        {
            // Add Payment Methods
            if (!dbContext.PaymentMethods.Any())
            {
                dbContext.PaymentMethods.AddRange(
                    new PaymentMethod { PaymentMethodName = "Credit Card" },
                    new PaymentMethod { PaymentMethodName = "Bank Transfer" }
                );
                dbContext.SaveChanges();
            }

            // Add Vendors
            if (!dbContext.Vendors.Any())
            {
                dbContext.Vendors.AddRange(
                    new Vendor
                    {
                        VendorName = "Vendor A",
                        Email = "vendorA@example.com",
                        VendorAddress = "123 Vendor St.",
                        PaymentMethodId = 1 // Referencing "Credit Card" payment method
                    },
                    new Vendor
                    {
                        VendorName = "Vendor B",
                        Email = "vendorB@example.com",
                        VendorAddress = "456 Vendor Ave.",
                        PaymentMethodId = 2 // Referencing "Bank Transfer" payment method
                    }
                );
                dbContext.SaveChanges();
            }
        }
    }
}
