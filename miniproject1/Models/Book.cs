using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace miniproject1.Models
{
    internal class Book
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Genre Genre { get; set; }



        public Book()
        {
            Id = ++_id;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Author: {Author.Name}, Genre: {Genre.Name}, Stock: {Stock}, Price: {Price:C}";
        }
    }
}
