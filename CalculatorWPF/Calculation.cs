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

            if (!Double.TryParse(numberStr, out numberDouble))
            {
                return result;
            }

            result += numberDouble;

            return result;
        }

        public double subtractNumber(string numberStr)
        {
            double numberDouble;

            if(!Double.TryParse(numberStr, out numberDouble))
            {
                return result;
            }

            result -= numberDouble;

            return result;
        }

        public double multiplyNumber(string numberStr)
        {
            double numberDouble;

            if (!Double.TryParse(numberStr, out numberDouble))
            {
                return result;
            }

            result *= numberDouble;

            return result;
        }

        public double divideNumber(string numberStr)
        {
            double numberDouble;

            if (!Double.TryParse(numberStr, out numberDouble))
            {
                return result;
            }

            result /= numberDouble;

            return result;
        }

    }
}

