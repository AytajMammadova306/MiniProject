using miniproject1.Models;
using miniproject1.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace miniproject1.Services
{
    internal class BookService
    {
        private List<Book> Books { get; set; } = new List<Book>();
        private GenreService GenreService { get; set; }
        private AuthorService AuthorService { get; set; }
        public BookService(GenreService genreService, AuthorService authorService)
        {
            GenreService = genreService;
            AuthorService = authorService;
        }
        public void AddBook()
        {
            Console.Write("Enter the title of the book:");
            string title = Console.ReadLine();
            int idAuthor;
            do
            {
                Console.Write("Enter the ID of the author of the book:");
                AuthorService.ShowAllAuthors();
                string answer = Console.ReadLine();
                Console.Clear();
                bool result = int.TryParse(answer, out idAuthor);
                if (!result || AuthorService.GetAuthorById(idAuthor) == null)
                {
                    Console.WriteLine("Entry is wrong or author not found.");
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else break;
            } while (true);
            int idGenre;
            do
            {
                Console.Write("Enter the ID of the genre of the book:");
                GenreService.ShowAllGenres();
                string answer = Console.ReadLine();
                Console.Clear();
                bool result = int.TryParse(answer, out idGenre);
                if (!result || GenreService.GetGenreById(idGenre) == null)
                {
                    Console.WriteLine("Entry is wrong or genre not found.");
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else break;
            } while (true);
            decimal price;
            do
            {
                Console.WriteLine("Enter the price of the book:");
                string answer = Console.ReadLine();
                Console.Clear();
                bool result = decimal.TryParse(answer, out price);
                if (!result)
                {
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else break;
            } while (true);
            Book book = new Book
            {
                Title = title,
                Author = AuthorService.GetAuthorById(idAuthor),
                Genre = GenreService.GetGenreById(idGenre),
                Price = price
            };
            Books.Add(book);
            Console.WriteLine("Created successfully.");
        }
        public void ShowAllBooks()
        {
            Console.WriteLine("Books:");
            foreach (var book in Books)
            {
                Console.WriteLine(book);
            }

        }
        public void DeleteBook()
        {
            ShowAllBooks();
            Console.Write("Enter the ID of the book to delete:");
            string answer = Console.ReadLine();
            Console.Clear();
            bool result = int.TryParse(answer, out int id);
            if (!result)
            {
                Console.WriteLine("Entry is wrong.");
                return;
            }
            var book = Books.Find(b => b.Id == id);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            Books.Remove(book);
            Console.WriteLine("Deleted successfully.");
        }
        public void ShowBooksByGenre()
        {
            GenreService.ShowBooksByGenre();

        }
        public void ShowBooksByName()
        {
            Console.Write("Enter the name of the book:");
            string name = Console.ReadLine();
            var book = Books.Find(b => b.Title.ToUpper() == name.ToUpper());
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            Console.WriteLine(book);
        }
        public void ShowBooksByAuthor()
        {
            AuthorService.ShowBooksByAuthor();
        }
        public void EditBook()
        {
            int id;
            Book book = null;
            do
            {
                Console.Write("Enter the ID of the book to edit:");
                ShowAllBooks();
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
                book = Books.Find(b => b.Id == id);
                if (book == null)
                {
                    Console.WriteLine("book not found.");
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else break;
            } while (true);
            Console.WriteLine("What would you like to edit?");
            Console.WriteLine("1. Title\n2. Stock\n3. Price");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.Clear();
            Console.Write("Old book details: ");
            Console.WriteLine(book);
            switch (choice)
            {
                case "1":
                    Console.Write("Enter the new title of the book:");
                    string title = Console.ReadLine();
                    book.Title = title;
                    Console.WriteLine("Edited successfully.");
                    break;
                case "2":
                    int stock;
                    do
                    {
                        Console.WriteLine("Enter the new stock of the book:");
                        string answer = Console.ReadLine();
                        Console.Clear();
                        bool result = int.TryParse(answer, out stock);
                        if (!result)
                        {
                            bool loop = Extentions.TryAgain();
                            if (!loop)
                            {
                                return;
                            }
                        }
                        else break;
                    } while (true);
                    book.Stock = stock;
                    break;
                case "3":
                    decimal price;
                    do
                    {
                        Console.WriteLine("Enter the new price of the book:");
                        string answer = Console.ReadLine();
                        Console.Clear();
                        bool result = decimal.TryParse(answer, out price);
                        if (!result)
                        {
                            bool loop = Extentions.TryAgain();
                            if (!loop)
                            {
                                return;
                            }
                        }
                        else break;
                    } while (true);
                    book.Price = price;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

    }
    
}
