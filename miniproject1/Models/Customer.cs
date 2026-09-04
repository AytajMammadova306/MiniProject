using System;
using System.Collections.Generic;
using System.Text;

namespace miniproject1.Models
{
    internal class Customer
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public Customer()
        {
            Id=++_id;
        }
    }
}
