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


        
        public void buttonPlusClicked(string numberStr)
        {
            window.setResultLabel(model.addNumber(numberStr));
            window.appendToHistorylabel(numberStr + " + ");
        }

        public void buttonMinusClicked(string numberStr)
        {
            window.setResultLabel(model.subtractNumber(numberStr));
            window.appendToHistorylabel(numberStr + " - ");
        }

        public void buttonMultiplyClicked(string numberStr)
        {
            model.subtractNumber(numberStr);
        }

        public void buttonDivideClicked(string numberStr)
        {
            model.divideNumber(numberStr);
        }


    }


}
