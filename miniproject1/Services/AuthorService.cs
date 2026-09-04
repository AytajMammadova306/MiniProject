using miniproject1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniproject1.Services
{
    internal class AuthorService
    {
        private List<Author> Authors { get; set; } = new List<Author>();

        public void AddAuthor()
        {
            Console.Write("Enter author name: ");
            string name = Console.ReadLine();
            var author = Authors.Find(a => a.Name.ToUpper() == name.ToUpper());
            if (author == null)
            {
                Authors.Add(new Author { Name = name });
                Console.WriteLine("Author created successfully.");
            }
            else Console.WriteLine("Author already exists.");
        }
        public void ShowAllAuthors()
        {
            Console.WriteLine("Authors:");
            foreach (var author in Authors)
            {
                Console.WriteLine($"Id: {author.Id}, Name: {author.Name}");
            }
        }
        public void ShowBooksByAuthor()
        {
            Console.Write("Enter author name: ");
            string name = Console.ReadLine();
            var author = Authors.Find(a => a.Name.ToUpper() == name.ToUpper());
            if (author != null)
            {
                Console.WriteLine($"Books by {author.Name}:");
                foreach (var book in author.Books)
                {
                    Console.WriteLine($"Title: {book.Title}, Genre: {book.Genre}, Price: {book.Price}");
                }
            }
            else Console.WriteLine("Author not found.");
        }
        public Author GetAuthorById(int id)
        {
            return Authors.Find(a => a.Id == id);
        }
    }
}
