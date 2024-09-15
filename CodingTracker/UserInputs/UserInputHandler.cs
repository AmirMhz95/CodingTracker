using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInputs;

namespace UserInputs
{
    public class UserInputHandler
    {
        private readonly IInputHandler<DateTime> _dateInputHandler;
        private readonly IInputHandler<TimeSpan> _startTimeInputHandler;
        private readonly IInputHandler<TimeSpan> _endTimeInputHandler;

        public UserInputHandler(IInputHandler<DateTime> dateInputHandler, IInputHandler<TimeSpan> startTimeInputHandler, IInputHandler<TimeSpan> endTimeInputHandler)
        {
            _dateInputHandler = dateInputHandler;
            _startTimeInputHandler = startTimeInputHandler;
            _endTimeInputHandler = endTimeInputHandler;
        }

        public UserInput GetUserInput()
        {
            return new UserInput
            {
                Date = _dateInputHandler.GetInput().ToString("yyyy-MM-dd"),
                StartTime = _startTimeInputHandler.GetInput().ToString(@"hh\:mm\:ss"),
                EndTime = _endTimeInputHandler.GetInput().ToString(@"hh\:mm\:ss")
            };
        }
    }
}
