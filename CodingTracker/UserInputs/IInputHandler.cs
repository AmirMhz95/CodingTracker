using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInputs
{
    public interface IInputHandler<T>
    {
        T GetInput();
    }
}
