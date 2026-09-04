using System;
using System.Collections.Generic;
using System.Text;

namespace miniproject1.Models
{
    internal class OrderItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal => Book.Price * Quantity;
    }
}
