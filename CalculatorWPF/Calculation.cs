using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    public class Calculation
    {
        //reference to controler
        Controler controler;

        Int64 result = 0;

        public Calculation(Controler con)  { controler = con; }

        //adding number to current result
        public Int64 addNumber(string numberStr)
        {
            Int64 numberInt;

            try
            {
                numberInt = Int64.Parse(numberStr);
            }
            catch (ArgumentNullException)
            {
                return result;
            }
            catch(OverflowException)
            {
                return result;
            }

            result += numberInt;

            return result;
        }

        public Int64 subtractNumber(string numberStr)
        {


            return result;
        }
    }
}

