using System;
using System.Collections.Generic;
using System.Text;

namespace miniproject1.Utilities
{
    internal class Extentions
    {
        public static bool TryAgain()
        {
            do
            {
                Console.WriteLine("Would you like to try again?(Y/N)");
                string answer = Console.ReadLine();
                if (answer.ToUpper() == "Y")
                {
                    Console.Clear();
                    return true;
                }
                else if (answer.ToUpper() == "N")
                {
                    Console.Clear();
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter Y or N");
                }
            } while (true);
        }
        public static bool AddAnother()
        {
            do
            {
                Console.WriteLine("Would you like to add another?(Y/N)");
                string answer = Console.ReadLine();
                if (answer.ToUpper() == "Y")
                {
                    Console.Clear();
                    return true;
                }
                else if (answer.ToUpper() == "N")
                {
                    Console.Clear();
                    return false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter Y or N");
                }
            } while (true);
        }
    }
}
