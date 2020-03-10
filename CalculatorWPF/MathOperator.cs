using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    public class MathOperator
    {
        public enum OperatorEnum
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            LeftBracket,
            RightBracket,
            Square,
            Power,
            Logarithm,
            NaturalLogarithm,
            Sinus,
            Cosinus,
            Inverse,
            None
        }

        public MathOperator(OperatorEnum oper)
        {
            _mathOperator = oper;

          
            if (oper == OperatorEnum.Add || oper == OperatorEnum.Subtract || oper == OperatorEnum.None)
                _priority = 1;
            else if (oper == OperatorEnum.Multiply || oper == OperatorEnum.Divide)
                _priority = 2;
            else if (oper == OperatorEnum.Power || oper == OperatorEnum.Square)
                _priority = 3;
            else if (oper == OperatorEnum.LeftBracket || oper ==OperatorEnum.RightBracket)
                _priority = 4;
            else if (oper == OperatorEnum.Logarithm || oper == OperatorEnum.NaturalLogarithm || 
                oper == OperatorEnum.Sinus || oper == OperatorEnum.Cosinus || oper == OperatorEnum.Inverse)
                _priority = 5;
            else
                _priority = 0;
        }

        public OperatorEnum mathOperator { get { return _mathOperator; } }
        readonly private OperatorEnum _mathOperator;
        
        public int priority { get { return _priority; } }
        readonly private int _priority;
    }
}
