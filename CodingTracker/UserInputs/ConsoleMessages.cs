using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInputs
{
    public static class ConsoleMessages
    {

        public static void ShowMenuMessage()
        {
            Console.WriteLine("Welcome to Coding Tracker! What would you like to do?");
            Console.WriteLine("1. Add new entry");
            Console.WriteLine("2. View all entries");
            Console.WriteLine("3. Update an entry");
            Console.WriteLine("4. Delete an entry");
            Console.WriteLine("5. Exit");
        }

        public static void ShowErrorMessage(string message)
        {
            Console.WriteLine($"Error: {message}");
        }

        public static void ShowExitMessage(string message)
        {
            Console.WriteLine($"Exit: {message}");
        }

        public static void ShowSuccessMessage(string message)
        {
            Console.WriteLine($"Success: {message}.");
        }

        public static void ShowInforMessage(string message)
        {
            Console.WriteLine($"Info: {message}.");
        }
    }
}
