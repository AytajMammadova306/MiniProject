using System;
using System.Collections.Generic;
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
    }
}
