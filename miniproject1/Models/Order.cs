using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace miniproject1.Models
{
    internal class Order
    {
        private static int _id = 0;
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public Order()
        {
            Id=++_id;
        }
        public void PrintInfo()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine($"Order: {Id}\nCustomer: {Customer.Name}");
            Console.WriteLine("\n****************************************");
            Console.WriteLine($"   Name  \tPrice\tCount\tSubtotal\n");
            for(int i =0; i<OrderItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}.  {OrderItems[i].Book.Title}\t{OrderItems[i].Book.Price:C}\t{OrderItems[i].Quantity}\t{OrderItems[i].SubTotal:C}");
            }
            Console.Write($"\n\n\t\t\tTotal:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t{TotalAmount:C}\n");
            Console.ResetColor();
            Console.WriteLine("******************************************");
            Console.WriteLine($"Email:{Customer.Email}\nOrder Date{OrderDate.ToString()}");
            Console.WriteLine("===========================================");
        }
    }
}
