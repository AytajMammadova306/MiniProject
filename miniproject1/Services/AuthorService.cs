using miniproject1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniproject1.Services
{
    internal class AuthorService
    {
        public List<Author> Authors { get; set; } = new List<Author>();

        public void AddAuthor()
        {
            Console.Write("Enter author name: ");
            string name = Console.ReadLine();
            Console.Clear();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty.");
                Console.ResetColor();
                return;
            }
            var author = Authors.Find(a => a.Name.ToUpper() == name.ToUpper());
            if (author == null)
            {
                Authors.Add(new Author { Name = name });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author created successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Author already exists.");
                Console.ResetColor();
            }
        }
        public void ShowAllAuthors()
        {
            if (Authors.Count > 0)
            {
                Console.WriteLine("Authors:");
                foreach (var author in Authors)
                {
                    Console.WriteLine($"Id: {author.Id}, Name: {author.Name}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No authors found.");
                Console.ResetColor();
            }
            ;
        }
        public Author GetAuthorById(int id)
        {
            return Authors.Find(a => a.Id == id);
        }
    }
}
