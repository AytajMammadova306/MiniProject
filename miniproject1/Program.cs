using miniproject1.Services;

namespace miniproject1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenreService genreService = new GenreService();
            AuthorService authorService = new AuthorService();
            BookService bookService = new BookService(genreService, authorService);
            do
            {
                Console.WriteLine("*** BOOKSTORE SYSTEM ***\n");
                Console.WriteLine("1. Kitablar\n1.1 Yeni Kitab Elave Et" +
                    "\n1.2 Kitab Siyahisi\n1.3 Kitabi janr ile axtar\n" +
                    "1.4 Kitabi muellif ile axtar\n" +
                    "1.5 Kitabi ad ile axtar\n" + 
                    "1.6 Kitabi Redakte Et\n1.5 Kitabi Sil");
                Console.WriteLine("Müəlliflər");
                Console.WriteLine("2.1. Yeni müəllif əlavə et\n" +
                    "2.2. Bütün müəllifləri göstər\n2.3. Müəllifin kitablarını göstər");
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
