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
            Console.WriteLine("Enter customer email: ");
            string email = Console.ReadLine();
            if(Customers.Exists(c => c.Email.ToUpper() == email.ToUpper()))
            {
                Console.WriteLine("Customer with this email already exists.");
                return;
            }
            else
            {
                Customers.Add(new Customer { Name = name, Email = email });
                Console.WriteLine("Customer created successfully.");
            }

        }
        public void ShowAllCustomers()
        {
            Console.WriteLine("Customers:");
            foreach (var customer in Customers)
            {
                Console.WriteLine(customer);
            }
        }
        public void AddOrder()
        {
            Console.WriteLine("Choose a customer to add an order for:");
            int id;
            Customer customer = null;
            do
            {
                ShowAllCustomers();
                Console.Write("Enter the ID of the customer to add an order for:");
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
            List<OrderItem> items = new List<OrderItem>();
            decimal total= 0;
            do
            {
                OrderItemService.AddOrderItem(items,total);
                Console.WriteLine("Order Item added successfully.");
                bool loop = Extentions.AddAnother();
                if(!loop)
                {
                    break;
                }
            } while (true);
            Order order = new Order { Customer = customer, OrderItems = items , TotalAmount=total};
        }
        public void ShowOrdersByCustomerId()
        {
            Console.WriteLine("Choose a customer to show orders for:");
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
                Console.WriteLine("No orders found for this customer.");
                return;
            }
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
        public void ShowOrdersByCustomerEmail()
        {
            Console.WriteLine("Enter customer email to show orders for:");
            string email = Console.ReadLine();
            var customer = Customers.Find(c => c.Email.ToUpper() == email.ToUpper());
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            var orders = Orders.FindAll(o => o.Customer.Id == customer.Id);
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found for this customer.");
                return;
            }
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
        public void ShowAllOrders()
        {

            Console.WriteLine("Orders:");
            foreach (var order in Orders)
            {
                Console.WriteLine(order);
            }
        }
    }
}
