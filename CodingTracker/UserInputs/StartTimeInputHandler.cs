using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInputs;

namespace UserInputs
{
    public class StartTimeInputHandler : IInputHandler<TimeSpan>
    {
        public TimeSpan GetInput()
        {
            Console.WriteLine("Enter the start time in the format HH:MM:SS:");
            string startTime = Console.ReadLine();

            TimeSpan parsedStartTime;
            while (!TimeSpan.TryParse(startTime, out parsedStartTime))
            {
                Console.WriteLine("Invalid time format. Please enter the start time in the format HH:MM:SS:");
                startTime = Console.ReadLine();
            }

            return parsedStartTime;
        }
    }
}
