using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWPF
{
    class Operation
    {
        //fields
        public double? firstArgument
        {
            get
            {
                return _firstArgument;
            }
            set
            {
                _firstArgument = value;
            }
        }
        private double? _firstArgument = null;

        public double? secondArgument
        {
            get
            {
                return _secondArgument;
            }
            set
            {
                _secondArgument = value;
            }
        }
        private double? _secondArgument = null;

        private MathOperator _mathOperator = null;
        //fields

        //constructors
        public Operation(MathOperator operatorEnum, double? firstArg = null)
        {
            _mathOperator = operatorEnum;
            _firstArgument = firstArg;
        }

        public Operation() { }
        //constructors

        //seeters and getters
        public void setMathOperator(MathOperator value)
        {
            _mathOperator = value;
        }

        public MathOperator getMathOperator()
        {
            return _mathOperator;
        }
        //setters and getters

        //return true if priority is lower than @secondOperator
        public bool HasLowerPriority(MathOperator secondOperator)
        {
            if (_mathOperator != null)
            {
                if (_mathOperator.priority < secondOperator.priority)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool HasTheSamePriority(MathOperator secondOperator)
        {
            if (_mathOperator.priority == secondOperator.priority)
                return true;
            else
                return false;
        }

        public bool HasHigherPriority(MathOperator secondOperator)
        {
            if (_mathOperator != null)
            {
                if (_mathOperator.priority > secondOperator.priority)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public double DoOperation()
        {
            if(_firstArgument == null || _secondArgument == null || _mathOperator == null)
            {
                //throw exception

                return Double.MinValue;
            }
            else
            { 
                switch (_mathOperator.mathOperator)
                {
                    case MathOperator.OperatorEnum.Add:
                        _firstArgument += _secondArgument;
                        _secondArgument = null;
                        break;

                    case MathOperator.OperatorEnum.Subtract:
                        _firstArgument -= _secondArgument;
                        _secondArgument = null;
                        break;

                    case MathOperator.OperatorEnum.Multiply:
                        _firstArgument *= _secondArgument;
                        _secondArgument = null;
                        break;

                    case MathOperator.OperatorEnum.Divide:
                        if (_secondArgument == 0.0)
                        {
                            //throw excpetion

                            return 0.0;
                        }
                        _firstArgument /= _secondArgument;
                        _secondArgument = null;
                        break;

                    case MathOperator.OperatorEnum.Power:
                        _firstArgument = Math.Pow((Double) _firstArgument, (Double) _secondArgument);
                        _secondArgument = null;
                        break;
                }

                return (Double)_firstArgument;
            }
        }

    }
}
