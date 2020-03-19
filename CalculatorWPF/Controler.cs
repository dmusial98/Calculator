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

        public void buttonPlusClicked(string numberString)
        {
            window.setResultLabel(model.Count(numberString, new MathOperator(MathOperator.OperatorEnum.Add)));
            window.appendToHistorylabel(numberString + "+");
        }

        public void buttonMinusClicked(string numberString)
        {
            window.setResultLabel(model.Count(numberString, new MathOperator(MathOperator.OperatorEnum.Subtract)));
            window.appendToHistorylabel(numberString + "-");
        }
        
        public void buttonMultiplyClicked(string numberString)
        {
            window.setResultLabel(model.Count(numberString, new MathOperator(MathOperator.OperatorEnum.Multiply)));
            window.appendToHistorylabel(numberString + "*");
        }

        public void buttonDivideClicked(string numberString)
        {
            window.setResultLabel(model.Count(numberString, new MathOperator(MathOperator.OperatorEnum.Divide)));
            window.appendToHistorylabel(numberString + "/");
        }

        public void buttonPowerClicked(string numberString)
        {
            window.setResultLabel(model.Count(numberString, new MathOperator(MathOperator.OperatorEnum.Power)));
            window.appendToHistorylabel(numberString + "^");
        }

        public void buttonLeftBracketClicked()
        {
            model.LeftBracketService();
            window.appendToHistorylabel("(");
        }

        public void buttonRightBracketClicked(string numberString)
        {
            window.setResultLabel(model.RightBracketService(numberString));
            window.appendToHistorylabel(numberString + ")");
        }

        public void buttonEqualsClicked()
        {

        }

        public void ClearButtonClicked()
        {
            model.ClearOperations();
        }

    }


}
