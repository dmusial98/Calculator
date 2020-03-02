using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    public class Controler
    {
        //Main window for interacting with user
        MainWindow window;

        //Model for managing logic of calculator
        Calculation model;

        public Controler(MainWindow mw)
        {
            model = new Calculation(this);
            window = mw;
        }

        public void operationButtonClicked(string numberStr, OperationStruct operationStruct)
        {
            window.setResultLabel(model.Count(numberStr, operationStruct));

            string _operator = "";

            switch (operationStruct.operation)
            {
                case OperationStruct.Operation.Add :
                    _operator = " + ";
                    break;

                case OperationStruct.Operation.Subtract :
                    _operator = " - ";
                    break;

                case OperationStruct.Operation.Multiply :
                    _operator = " x ";
                    break;

                case OperationStruct.Operation.Divide :
                    _operator = " / ";
                    break;

                case OperationStruct.Operation.Power :
                    _operator = " ^ ";
                    break;

            }

            window.appendToHistorylabel(numberStr + _operator);
        }
        
    }


}
