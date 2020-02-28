using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    public struct OperationStruct
    {
        public enum Operation
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

        public OperationStruct(Operation oper)
        {
            _operation = oper;

          
            if (oper == Operation.Add || oper == Operation.Subtract || oper ==Operation.None)
                _priority = 1;
            else if (oper == Operation.Multiply || oper == Operation.Divide)
                _priority = 2;
            else if (oper == Operation.Power || oper == Operation.Square)
                _priority = 3;
            else if (oper == Operation.LeftBracket || oper == Operation.RightBracket)
                _priority = 4;
            else if (oper == Operation.Logarithm || oper == Operation.NaturalLogarithm || oper == Operation.Sinus || oper == Operation.Cosinus || oper == Operation.Inverse)
                _priority = 5;
            else
                _priority = 0;
        }

        public Operation operation { get { return _operation; } }
        readonly private Operation _operation;
        
        public int priority { get { return _priority; } }
        readonly private int _priority;
    }
}
