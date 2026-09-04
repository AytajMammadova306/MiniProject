using miniproject1.Models;
using miniproject1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace miniproject1.Services
{
    internal class CustomerService
    {
        private List<Customer> Customers { get; set; } = new List<Customer>();
        private List<Order> Orders { get; set; } = new List<Order>();
        private OrderItemService OrderItemService { get; set; }
        public CustomerService(OrderItemService orderItemService)
        {
            OrderItemService = orderItemService;
        }
        public void AddCustomer()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter customer email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email cannot be empty.");
                Console.ResetColor();
                return;
            }
            if (Customers.Exists(c => c.Email.ToUpper() == email.ToUpper()))
            {
                Console.WriteLine("Customer with this email already exists.");
                return;
            }
            else
            {
                Customers.Add(new Customer { Name = name, Email = email });
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Customer created successfully.");
                Console.ResetColor();
            }

        }
        public void ShowAllCustomers()
        {
            if (Customers.Count > 0)
            {
                Console.WriteLine("Customers:");
                foreach (var customer in Customers)
                {
                    Console.WriteLine(customer);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No customers available.");
                Console.ResetColor();
            }
        }
        public void AddOrder()
        {
            if (Customers.Count == 0 || OrderItemService.BookService.Books.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No books or customers available to create an order. Please add books and customers first.");
                Console.ResetColor();
                return;
            }
            int id;
            Customer customer = null;
            do
            {
                ShowAllCustomers();
                Console.Write("Enter the ID of the customer to add an order for:");
                string answer = Console.ReadLine();
                Console.Clear();
                bool result = int.TryParse(answer, out id);
                customer = Customers.Find(c => c.Id == id);
                if (!result)
                {
                    Console.WriteLine("Entry is wrong");
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else if (customer == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Customer not found.");
                    Console.ResetColor();
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else break;
            } while (true);
            List<OrderItem> items = new List<OrderItem>();;
            do
            {
                OrderItemService.AddOrderItem(items);
                Console.WriteLine("Order Item added successfully.");
                bool loop = Extentions.AddAnother();
                if(!loop)
                {
                    break;
                }
            } while (true);
            decimal totalAmount = 0;
            foreach (var item in items)
            {
                totalAmount += item.SubTotal;
            }
            Order order = new Order { Customer = customer, OrderItems = items , TotalAmount = totalAmount };
            Orders.Add(order);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Order created successfully.");
            Console.ResetColor();
        }
        public void ShowOrdersByCustomerId()
        {
            if(Customers.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No customers available.");
                Console.ResetColor();
                return;
            }
            int id;
            Customer customer = null;
            do
            {
                ShowAllCustomers();
                Console.Write("Enter the ID of the customer to show orders for:");
                string answer = Console.ReadLine();
                Console.Clear();
                bool result = int.TryParse(answer, out id);
                if (!result)
                {
                    Console.WriteLine("Entry is wrong");
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                customer = Customers.Find(c => c.Id == id);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else break;
            } while (true);
            var orders = Orders.FindAll(o => o.Customer.Id == customer.Id);
            if (orders.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No orders found for this customer.");
                Console.ResetColor();
                return;
            }
            foreach (var order in orders)
            {
                order.PrintInfo();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress any Key to go back to Main Menu...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        public void ShowOrdersByCustomerEmail()
        {
            if(Customers.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No customers available.");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("Enter customer email to show orders for:");
            string email = Console.ReadLine();
            Console.Clear();
            var customer = Customers.Find(c => c.Email.ToUpper() == email.ToUpper());
            if (customer == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Customer not found.");
                Console.ResetColor();
                return;
            }
            var orders = Orders.FindAll(o => o.Customer.Id == customer.Id);
            if (orders.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No orders found for this customer.");
                Console.ResetColor();
                return;
            }
            foreach (var order in orders)
            {
                order.PrintInfo();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress any Key to go back to Main Menu...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        public void ShowAllOrders()
        {
            if (Orders.Count > 0)
            {
                Console.WriteLine("Orders:");
                foreach (var order in Orders)
                {
                    order.PrintInfo();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPress any Key to go back to Main Menu...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No orders available.");
                Console.ResetColor();
                return;
            }
        }
    }
}
