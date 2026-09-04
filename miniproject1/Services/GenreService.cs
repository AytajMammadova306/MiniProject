using miniproject1.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace miniproject1.Services
{
    internal class GenreService
    {
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public void AddGenre()
        {
            Console.Write("Enter Genre Name: ");
            string name = Console.ReadLine();
            Console.Clear();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty.");
                Console.ResetColor();
                return;
            }
            var genre = Genres.Find(g => g.Name.ToUpper() == name.ToUpper());
            if (genre == null)
            {
                Genre newGenre = new Genre { Name = name };
                Genres.Add(newGenre);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Genre created successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Genre already exists.");
                Console.ResetColor();
            }
        }
        public void ShowAllGenres()
        {
            if (Genres.Count > 0)
            {
                Console.WriteLine("Genres:");
                foreach (var genre in Genres)
                {
                    Console.WriteLine($"Id: {genre.Id}, Name: {genre.Name}");
                }
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No genres available.");
                Console.ResetColor();
            }
        }
        public Genre GetGenreById(int id)
        {
            return Genres.Find(g => g.Id == id);
        }

    }
}
