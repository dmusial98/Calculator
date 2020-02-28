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
        Operation operation = Operation.None;
        bool isFirstOperation = true;

        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide, 
            None
        }

        //variable for storing information about new operation
        

        public Calculation(Controler con)
        {
            controler = con;
        }


        public double doBasicOperation(string numberStr, Operation oper)
        {
            double numberDouble;

            if (!Double.TryParse(numberStr, out numberDouble))
            {
                return result;
            }

            if (isFirstOperation)
            {
                result = numberDouble;
                isFirstOperation = false;
            }
            else  //when calculator has second or later operator
            {
                switch (operation)
                {
                    case Operation.Add:

                        result += numberDouble;
                        break;

                    case Operation.Subtract:
                        result -= numberDouble;
                        break;

                    case Operation.Multiply:
                        result *= numberDouble;
                        break;

                    case Operation.Divide:
                        result /= numberDouble;
                        break;
                }

            }

            operation = oper;
            return result;
        }

    }
}

