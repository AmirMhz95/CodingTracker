using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInputs
{
    public class DateInputHandler : IInputHandler<DateTime>
    {
        public DateTime GetInput()
        {
            Console.WriteLine("Enter the date in the format yyyy-MM-dd:");
            string date = Console.ReadLine();

            DateTime parsedDate;
            while (!DateTime.TryParse(date, out parsedDate))
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format yyyy-MM-dd:");
                date = Console.ReadLine();
            }

            return parsedDate;
        }
    }
}

