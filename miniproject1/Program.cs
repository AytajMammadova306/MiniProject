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
                Console.WriteLine("*** BOOKSTORE SYSTEM ***\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Kitablar");
                Console.ResetColor();
                Console.WriteLine(
                    "\n1.1 Yeni Kitab Əlavə Et" +
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
                    "\n2.1. Yeni müəllif əlavə et" +
                    "\n2.2. Bütün müəllifləri göstər" +
                    "\n2.3. Müəllifin kitablarını göstər");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Janrlar");
                Console.ResetColor();
                Console.WriteLine(
                    "\n3.1. Janr əlavə et" +
                    "\n3.2. Bütün janrları göstər" +
                    "\n3.3. Janra görə kitabları göstər");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Müştəri və Sifarişlər");
                Console.ResetColor();
                Console.WriteLine(
                    "\n4.1 Yeni müştəri qeydiyyatı" +
                    "\n4.2 Bütün müştəriləri göstər" +
                    "\n4.3 Yeni sifariş yarat" +
                    "\n4.4 Müştərinin sifarişlərini göstər (ID ilə)" +
                    "\n4.5 Müştərinin sifarişlərini göstər (email ilə)" +
                    "\n4.6 Bütün sifarişləri göstər");

                Console.WriteLine("0. Exit\n\n");

                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "1" or "1.":
                        bookService.AddBook();
                        break;
                    case "1.2":
                        bookService.ShowAllBooks();
                        break;
                    case "1.3":
                        bookService.ShowBooksByGenre();
                        break;
                    case "1.4":
                        bookService.ShowBooksByAuthor();
                        break;
                    case "1.5":
                        bookService.ShowBooksByName();
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
                        break;
                    case "2.3":
                        authorService.ShowBooksByAuthor();
                        break;
                    case "3.1":
                        genreService.AddGenre();
                        break;
                    case "3.2":
                        genreService.ShowAllGenres();
                        break;
                    case "3.3":
                        genreService.ShowBooksByGenre();
                        break;
                    case "4.1":
                        customerService.AddCustomer();
                        break;
                    case "4.2":
                        customerService.ShowAllCustomers();
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
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                
            } while (true);
        }
    }
}
