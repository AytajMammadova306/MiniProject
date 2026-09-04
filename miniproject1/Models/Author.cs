using System;
using System.Collections.Generic;
using System.Text;

namespace miniproject1.Models
{
    internal class Author
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Name { get; set; }

        public Author()
        {
            Id= ++_id;
        }
    }
}
