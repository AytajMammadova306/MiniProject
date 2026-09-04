using miniproject1.Models;
using miniproject1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace miniproject1.Services
{
    internal class OrderItemService
    {
        private BookService BookService;
        public OrderItemService(BookService bookService)
        {
            BookService = bookService;
        }
        public void AddOrderItem(List<OrderItem> orderItems, decimal total)
        {
            Console.WriteLine("Choose a book to add to the order:");
            BookService.ShowAllBooks();
            int id;
            Book book = null;
            do
            {
                BookService.ShowAllBooks();
                Console.Write("Enter the ID of the book to order:");
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
                book = BookService.Books.Find(b => b.Id == id);
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
            Console.WriteLine($"How many of {book.Title} do you want to order?");
            int quantity;
            do
            {
                Console.Write("Enter the quantity:");
                string answer = Console.ReadLine();
                Console.Clear();
                bool result = int.TryParse(answer, out quantity);
                if (!result)
                {
                    Console.WriteLine("Invalid quantity entered.");
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                if(quantity >= book.Stock)
                {
                    Console.WriteLine($"Not enough stock. Available stock: {book.Stock}");
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                if(quantity <= 0 &&result)
                {
                    Console.WriteLine("Quantity must be greater than 0.");
                    bool loop = Extentions.TryAgain();
                    if (!loop)
                    {
                        return;
                    }
                }
                else break;
            } while (true);
            total += book.Price * quantity;
            OrderItem oi=orderItems.Find(o => o.Book.Id == book.Id);
            if (oi == null) orderItems.Add(new OrderItem { Book = book, Quantity = quantity, });
            else oi.Quantity += quantity;

        }
    }
}
