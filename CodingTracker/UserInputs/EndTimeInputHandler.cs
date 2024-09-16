using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInputs;

namespace UserInputs
{
    public class EndTimeInputHandler : IInputHandler<TimeSpan>
    {
        public TimeSpan GetInput()
        {
            Console.WriteLine("Enter the end time in the format HH:MM:SS:");
            string endTime = Console.ReadLine();
            
            TimeSpan parsedEndTime;
            while (!TimeSpan.TryParse(endTime, out parsedEndTime))
            {
                Console.WriteLine("Invalid time format. Please enter the end time in the format HH:MM:SS:");
                endTime = Console.ReadLine();
            }

            return parsedEndTime;
        }
    }
}
