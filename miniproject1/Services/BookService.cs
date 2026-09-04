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
        public List<Book> Books { get; set; } = new List<Book>();
        private GenreService GenreService { get; set; }
        private AuthorService AuthorService { get; set; }
        public BookService(GenreService genreService, AuthorService authorService)
        {
            GenreService = genreService;
            AuthorService = authorService;
        }
        public void AddBook()
        {
            if(AuthorService.Authors.Count == 0|| GenreService.Genres.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add author and genre first.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();
            Console.Clear();
            if(string.IsNullOrWhiteSpace(title))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Title cannot be empty.");
                Console.ResetColor();
                return;
            }
            int idAuthor;
            do
            {
                AuthorService.ShowAllAuthors();
                Console.Write("Enter the ID of the author of the book:");
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
                GenreService.ShowAllGenres();
                Console.Write("Enter the ID of the genre of the book:");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid price format.");
                    Console.ResetColor();
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else if(result && price <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Price cannot be less than or equal to zero.");
                    Console.ResetColor();
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else break;
            } while (true);
            int stock;
            do
            {
                Console.WriteLine("Enter the new stock of the book:");
                string answer = Console.ReadLine();
                Console.Clear();
                bool result = int.TryParse(answer, out stock);
                if (!result)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    bool loop = Extentions.TryAgain();
                    Console.ResetColor();
                    if (!loop)
                    {
                        return;
                    }
                }
                else if (result && stock < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Stock cannot be less than zero.");
                    Console.ResetColor();
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
                Price = price,
                Stock = stock
            };
            if(Books.Find(b=>b.Title.ToUpper() == title.ToUpper()&&b.Author.Id == idAuthor)!= null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book already exists.");
                Console.ResetColor();
                return;
            }
            Books.Add(book);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Created successfully.");
            Console.ResetColor();
        }
        public void ShowAllBooks()
        {
            if (Books.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No books available.");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("Books:");
            foreach (var book in Books)
            {
                Console.WriteLine(book);
            }

        }
        public void DeleteBook()
        {
            if(Books.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No books available.");
                Console.ResetColor();
                return;
            }
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
            Console.Write("Enter Genre Name: ");
            string name = Console.ReadLine();
            Console.Clear();
            var genre = GenreService.Genres.Find(g => g.Name.ToUpper() == name.ToUpper());
            if (genre != null)
            {
                if (Books.FindAll(b => b.Genre.Name.ToUpper() == genre.Name.ToUpper()).Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"No books available in {genre.Name} genre.");
                    Console.ResetColor();
                    return;
                }
                Console.WriteLine($"Books in {genre.Name}:");
                foreach (var book in Books.FindAll(b => b.Genre.Name.ToUpper() == genre.Name.ToUpper()))
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author.Name}, Price: {book.Price}");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPress any Key to go back to Main Menu...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Genre not found.");
                Console.ResetColor();
            }

        }
        public void ShowBookByName()
        {
            if(Books.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No books available.");
                Console.ResetColor();
                return;
            }
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
            Console.Write("Enter author name: ");
            string name = Console.ReadLine();
            Console.Clear();
            var author = AuthorService.Authors.Find(a => a.Name.ToUpper() == name.ToUpper());
            if (author != null)
            { 
                if (Books.FindAll(b => b.Author.Name.ToUpper() == author.Name.ToUpper()).Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"No books found for author {author.Name}.");
                    Console.ResetColor();
                    return;
                }
                Console.WriteLine($"Books by {author.Name}:");
                foreach (var book in Books.FindAll(b => b.Author.Name.ToUpper() == author.Name.ToUpper()))
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author.Name}, Price: {book.Price}");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPress any Key to go back to Main Menu...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Author not found.");
                Console.ResetColor();
            }
        }
        public void EditBook()
        {
            if(Books.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No books available.");
                Console.ResetColor();
                return;
            }
            int id;
            Book book = null;
            do
            {
                ShowAllBooks();
                Console.Write("Enter the ID of the book to edit:");
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
            switch (choice)
            {
                case "1":
                    Console.WriteLine($"Old title: {book.Title}");
                    Console.Write("Enter the new title of the book:");
                    string title = Console.ReadLine();
                    Console.Clear();
                    book.Title = title;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Edited successfully.");
                    Console.ResetColor();
                    break;
                case "2":
                    int stock;
                    do
                    {
                        Console.WriteLine($"Old stock: {book.Stock}");
                        Console.WriteLine("Enter the new stock of the book:");
                        string answer = Console.ReadLine();
                        Console.Clear();
                        bool result = int.TryParse(answer, out stock);
                        if (!result)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            bool loop = Extentions.TryAgain();
                            Console.ResetColor();
                            if (!loop)
                            {
                                return;
                            }
                        }
                        else if(result && stock < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Stock cannot be less than zero.");
                            Console.ResetColor();
                            bool loop = Extentions.TryAgain();
                            if (!loop)
                            {
                                return;
                            }
                        }
                        else break;
                    } while (true);
                    book.Stock = stock;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Edited successfully.");
                    Console.ResetColor();
                    break;
                case "3":
                    decimal price;
                    do
                    {
                        Console.WriteLine($"Old price: {book.Price}");
                        Console.WriteLine("Enter the new price of the book:");
                        string answer = Console.ReadLine();
                        Console.Clear();
                        bool result = decimal.TryParse(answer, out price);
                        if (!result)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid price format.");
                            Console.ResetColor();
                            bool loop = Extentions.TryAgain();
                            if (!loop)
                            {
                                return;
                            }
                        }
                        else if (result && price <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Price cannot be less than or equal to zero.");
                            Console.ResetColor();
                            bool loop = Extentions.TryAgain();
                            if (!loop)
                            {
                                return;
                            }
                        }
                        else break;
                    } while (true);
                    book.Price = price;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Edited successfully.");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option.");
                    Console.ResetColor();
                    break;
            }
        }

    }
    
}
