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

        public void basicOprationButtonClicked(string numberStr, Calculation.Operation operation)
        {
            window.setResultLabel(model.doBasicOperation(numberStr, operation));

            string _operator = "";

            switch (operation)
            {
                case Calculation.Operation.Add :
                    _operator = " + ";
                    break;

                case Calculation.Operation.Subtract :
                    _operator = " - ";
                    break;

                case Calculation.Operation.Multiply :
                    _operator = " x ";
                    break;

                case Calculation.Operation.Divide :
                    _operator = " / ";
                    break;
            }

            window.appendToHistorylabel(numberStr + _operator);
        }
        
    }


}
