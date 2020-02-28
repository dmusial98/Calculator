using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    public class IncorrectInputDataException : Exception
    {
        string mistakeMessage = "Incorrect input!";
    }
}
