using miniproject1.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace miniproject1.Services
{
    internal class GenreService
    {
        private List<Genre> Genres { get; set; } = new List<Genre>();
        public void AddGenre()
        {
            Console.Write("Enter Genre Name: ");
            string name = Console.ReadLine();
            var genre = Genres.Find(g => g.Name.ToUpper() == name.ToUpper());
            if (genre == null)
            {
                Genre newGenre = new Genre { Name = name };
                Genres.Add(newGenre);
            }
            else Console.WriteLine("Genre already exists");
        }
        public void ShowAllGenres()
        {
            Console.WriteLine("Genres:");
            foreach (var genre in Genres)
            {
                Console.WriteLine($"Id: {genre.Id}, Name: {genre.Name}");
            }
        }
        public void ShowBooksByGenre()
        {
            Console.Write("Enter Genre Name: ");
            string name = Console.ReadLine();
            var genre = Genres.Find(g => g.Name.ToUpper() == name.ToUpper());
            if (genre != null)
            {
                Console.WriteLine($"Books in {genre.Name}:");
                foreach (var book in genre.Books)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Price: {book.Price}");
                }
            }
            else Console.WriteLine("Genre not found.");
        }
        public Genre GetGenreById(int id)
        {
            return Genres.Find(g => g.Id == id);
        }

    }
}
