using System;
using System.Collections.Generic;

public interface Idisplay // interface for displaying details
{
    void Display();
}

interface Ipayment // interface for processing payment
{
    void ProcessPayment(double amount);
}


public class Product : Idisplay // getting product details and displaying them
{
    public int ID{ get; set;}
    public string Name{get; set;}
    public double Price{get; set;}

    public Product(int i, string n, double p){ ID = i; Name = n; Price = p;}
    public void Display(){ Console.WriteLine($"Id: {ID}, Name: {Name}, Price: {Price}");}
}

public class Customer : Idisplay // getting customer details
{
    public string CustName{get; set;}
    public string Address{get; set;}

    public Customer(string name, string address)
    {
        CustName = name;
        Address = address;
    }

    public void UpdateDetails(string n, string a)
    {
        CustName = n; 
        Address = a;
        Console.WriteLine("Customer details updated successfully.");
    }

    public void Display()
    {
        Console.WriteLine($"Customer Name: {CustName}, Address: {Address}");
    }
}

public class Order // composing order with products and customer details
{
    public List<Product> Products {get; private set;}
    public Customer customer{get; set;}

    public Order(Customer customer)
    {
        this.customer = customer;
        Products = new List<Product>();
    }

    public void AddProduct(Product product) // adding product to the basket
    {
        Products.Add(product);
        Console.WriteLine($"Product '{product.Name}' added to the order.");
    }
    public void RemoveProduct(string productName) // removing product from the basket
    {
        var product = Products.Find(something => something.Name.ToUpper() == productName.ToUpper()); // this will find the product in the basket and remove it
        if (product != null)
        {
            Products.Remove(product);
            Console.WriteLine($"Product '{product.Name}' removed from the order.");
        }
        else
        {
            Console.WriteLine("Product not found in the order.");
        }
    }

    public double CalculateTotal() //  calculating total amount of the basket
    {
        double total = 0;
        foreach (var product in Products)
        {
            total += product.Price;
        }
        return total;
    }
}

public class CreditCardPayment : Ipayment // defining derived classes for different credit card payment methods
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount}...");
        Console.WriteLine("Payment successful.");
    }
}

public class DebitCardPayment : Ipayment // defining derived classes for different debit card payment methods
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing debit card payment of {amount}...");
        Console.WriteLine("Payment successful.");
    }
}

public class PayPalPayment : Ipayment // defining derived classes for different PayPal payment methods
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount}...");
        Console.WriteLine("Payment successful.");
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product> // creating a list of products to show them to the customer
        {
            new Product(1, "Macbook", 1500),
            new Product(2, "Ipad", 1200),
            new Product(3, "Iphone", 1300)
        };

        string name, address; // getting initial customer details
        Console.Write("Enter your name: ");
        name = Console.ReadLine();
        Console.Write("Enter your address: ");
        address = Console.ReadLine();

        Customer customer = new Customer(name, address);
        Order order = new Order(customer); // starting a new order for the customer
        
        Console.WriteLine("Hello, " + customer.CustName);
        string choice;
            do
            {
                Console.WriteLine("--- E-Commerce System Menu ---");
                Console.WriteLine("1. Display Products");
                Console.WriteLine("2. Display Basktet");
                Console.WriteLine("3. Add/Remove Products to Your Basket");
                Console.WriteLine("4. Place Order and Process Payment");
                Console.WriteLine("5. Update Customer Information");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // displaying products in the list
                        Console.WriteLine("Products Available:");
                        foreach (var product in products)
                        {
                            product.Display();
                        }
                        break;

                    case "2": // displaying products in the basket
                        if(order.Products.Count == 0)
                        {
                            Console.WriteLine("Your Basket is Empty.");
                        }
                        else
                        {
                            Console.WriteLine("Your Order:");
                            foreach (var product in order.Products)
                            {
                                product.Display();
                            }
                        }
                        break;
                    
                    case "3": // adding or removing products from the basket
                        bool stop = false;
                        while(!stop)
                        {
                            if(order.Products.Count == 0)
                            {
                                Console.WriteLine("Your Basket is Empty.");
                            }
                            else
                            {
                                Console.WriteLine("Your Order:");
                                foreach (var product in order.Products)
                                {
                                    product.Display();
                                }
                            }
                            Console.WriteLine("1. Add Product");
                            Console.WriteLine("2. Remove Product");
                            Console.Write("Enter your choice: ");
                            string edit = Console.ReadLine();

                            if (edit == "1")
                            {
                                Console.Write("Enter the Product Name to add to your order: ");
                                string productName = Console.ReadLine().ToUpper();
                                var productToAdd = products.Find(product => product.Name.ToUpper() == productName);

                                if (productToAdd != null)
                                {
                                    order.AddProduct(productToAdd);
                                }
                                else
                                {
                                    Console.WriteLine("Product not found.");
                                };
                            }
                            else if (edit == "2")
                            {
                                Console.Write("Enter the Product Name to remove: ");
                                string productName = Console.ReadLine();
                                order.RemoveProduct(productName);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                            Console.WriteLine("Do you want to add/remove more products? (Y/N)");
                            string more = Console.ReadLine();
                            if (more.ToUpper() == "N" || more.ToUpper() == "NO")
                            {
                                stop = true;
                            }
                        }
                        break;

                    case "4": // placing order and processing payment
                        Console.WriteLine("Do you want to place your order? (Y/N)");
                        string placeOrder = Console.ReadLine();

                        if(placeOrder.ToUpper() == "Y" || placeOrder.ToUpper() == "YES")
                        {
                            double total = order.CalculateTotal();
                            Console.WriteLine($"Total amount to pay: {total}");

                            Console.WriteLine("Do you want to update your details or use details below ? ");
                            customer.Display();
                            string updateDetails = Console.ReadLine();
                            if (updateDetails.ToUpper() == "Y" || updateDetails.ToUpper() == "YES") // this updates customer details if needed
                            {
                                Console.Write("Enter your name: ");
                                name = Console.ReadLine();
                                Console.Write("Enter your address: ");
                                address = Console.ReadLine();
                                customer.UpdateDetails(name, address);
                            }
                            else
                            {

                                Console.WriteLine("1. Credit Card");
                                Console.WriteLine("2. PayPal");
                                Console.WriteLine("3. Debit Card");
                                Console.WriteLine("Select payment method: ");
                                string paymentChoice = Console.ReadLine();

                                Ipayment payment = null;
                            switch (paymentChoice)
                            {
                                case "1":
                                    payment = new CreditCardPayment();
                                    break;
                                case "2":
                                    payment = new PayPalPayment();
                                    break;
                                case "3":
                                    payment = new DebitCardPayment();
                                    break;
                                default:
                                    payment = null;
                                    break;
                            }
                                if (payment != null)
                                {
                                    payment.ProcessPayment(total);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid payment method selected.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Order not placed.");
                        }
                        break;
                        
                    case "5": // updating customer details if needed
                        Console.Write("Enter your name: ");
                        string UpdatedName = Console.ReadLine();
                        Console.Write("Enter your address: ");
                        string UpdatedAddress = Console.ReadLine();

                        customer.UpdateDetails(UpdatedName, UpdatedAddress);
                        break;
                    
                    case "6": // exiting the program
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != "6");
        }
}
