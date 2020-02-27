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

        double result = 0;

        public Calculation(Controler con)  { controler = con; }

        //adding number to current result
        public double addNumber(string numberStr)
        {
            double numberDouble;

            try
            {
                numberDouble = Double.Parse(numberStr);
            }
            catch (ArgumentNullException)
            {
                return result;
            }
            catch(OverflowException)
            {
                return result;
            }

            result += numberDouble;

            return result;
        }

        public double subtractNumber(string numberStr)
        {


            return result;
        }
    }
}

