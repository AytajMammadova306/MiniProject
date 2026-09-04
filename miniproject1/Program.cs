using miniproject1.Services;

namespace miniproject1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            GenreService genreService = new GenreService();
            AuthorService authorService = new AuthorService();
            BookService bookService = new BookService(genreService, authorService);
            OrderItemService orderItemService = new OrderItemService(bookService);
            CustomerService customerService = new CustomerService(orderItemService);
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*** BOOKSTORE SYSTEM ***");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Kitablar");
                Console.ResetColor();
                Console.WriteLine(
                    "1.1 Yeni Kitab Əlavə Et" +
                    "\n1.2 Kitab Siyahısı" +
                    "\n1.3 Kitabı janr ilə axtar" +
                    "\n1.4 Kitabı müəllif ilə axtar" +
                    "\n1.5 Kitabı ad ilə axtar" +
                    "\n1.6 Kitabı Redaktə Et" +
                    "\n1.7 Kitabı Sil");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Müəlliflər");
                Console.ResetColor();
                Console.WriteLine(
                    "2.1. Yeni müəllif əlavə et" +
                    "\n2.2. Bütün müəllifləri göstər");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Janrlar");
                Console.ResetColor();
                Console.WriteLine(
                    "3.1. Janr əlavə et" +
                    "\n3.2. Bütün janrları göstər" );

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Müştəri və Sifarişlər");
                Console.ResetColor();
                Console.WriteLine(
                    "4.1 Yeni müştəri qeydiyyatı" +
                    "\n4.2 Bütün müştəriləri göstər" +
                    "\n4.3 Yeni sifariş yarat" +
                    "\n4.4 Müştərinin sifarişlərini göstər (ID ilə)" +
                    "\n4.5 Müştərinin sifarişlərini göstər (email ilə)" +
                    "\n4.6 Bütün sifarişləri göstər");

                Console.WriteLine("0. Exit\n");

                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "1" or "1.1":
                        bookService.AddBook();
                        break;
                    case "1.2":
                        bookService.ShowAllBooks();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPress any Key to go back to Main Menu...");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "1.3":
                        bookService.ShowBooksByGenre();
                        break;
                    case "1.4":
                        bookService.ShowBooksByAuthor();
                        break;
                    case "1.5":
                        bookService.ShowBookByName();
                        break;
                    case "1.6":
                        bookService.EditBook();
                        break;
                    case "1.7":
                        bookService.DeleteBook();
                        break;
                    case "2.1":
                        authorService.AddAuthor();
                        break;
                    case "2.2":
                        authorService.ShowAllAuthors();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPress any Key to go back to Main Menu...");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3.1":
                        genreService.AddGenre();
                        break;
                    case "3.2":
                        genreService.ShowAllGenres();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPress any Key to go back to Main Menu...");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4.1":
                        customerService.AddCustomer();
                        break;
                    case "4.2":
                        customerService.ShowAllCustomers();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPress any Key to go back to Main Menu...");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4.3":
                        customerService.AddOrder();
                        break;
                    case "4.4":
                        customerService.ShowOrdersByCustomerId();
                        break;
                    case "4.5":
                        customerService.ShowOrdersByCustomerEmail();
                        break;
                    case "4.6":
                        customerService.ShowAllOrders();
                        break;

                    case "0":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exiting the program.");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ResetColor();
                        break;
                }
                
            } while (true);
        }
    }
}
