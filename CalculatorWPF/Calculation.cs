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

        List<Operation> operations = new List<Operation>();

        public void ClearOperations()
        {
            while (operations.Count != 0)
                operations.RemoveAt(operations.Count - 1);
        }

        public Calculation(Controler con)
        {
            controler = con;
        }

        public double Count(string numberString, MathOperator newOperator)
        {
            double numberDouble;

            if (!Double.TryParse(numberString, out numberDouble))
            {
                //after right bracket user has given newOperator

                if(operations.Count != 1)
                {
                    if(operations[operations.Count - 2].HasLowerPriority(newOperator))
                    {
                        operations.Last().setMathOperator(newOperator);
                    }
                    else
                        //operations[operations.Count - 2].hasTheSamePriority(newOperator) || 
                        //operations[operations.Count - 2].hasHigherPriority(newOperator)
                    {
                        while (operations.Count != 1 && !operations[operations.Count - 2].IsInBrackets && 
                            (operations[operations.Count - 2].HasTheSamePriority(newOperator)
                            || operations[operations.Count - 2].HasHigherPriority(newOperator)))
                        {
                            moveArgDown();
                            operations.Last().DoOperation();
                        }
                    }
                    operations.Last().setMathOperator(newOperator);
                }
                else
                {
                    operations.Last().setMathOperator(newOperator);
                }

                return operations.Last().firstArgument ?? Double.MinValue;
                
            }

            if (operations.Count == 0)
                //first argument in calculation or first argument in new brackets
            {
                operations.Add(new Operation(newOperator, numberDouble));
                return numberDouble;
            }
            else //operations.Count > 0
            {
                if (operations.Last().firstArgument == null && operations.Last().IsInBrackets)
                //new empty operation in brackets
                {
                    operations.Last().firstArgument = numberDouble;
                    operations.Last().setMathOperator(newOperator);
                    return operations.Last().firstArgument ?? Double.MinValue;
                }
                else if (operations.Last().HasTheSamePriority(newOperator))
                    //the same priority
                {
                    operations.Last().secondArgument = numberDouble;
                    double result = operations.Last().DoOperation();
                    operations.Last().setMathOperator(newOperator);

                    return result;
                }
                else if (operations.Last().HasLowerPriority(newOperator))
                    //lower priority old operator's
                {
                    operations.Add(new Operation(newOperator, numberDouble));
                    return numberDouble;
                }
                else
                    //higher priority old operator's
                {
                    operations.Last().secondArgument = numberDouble;
                    operations.Last().DoOperation();

                    while (operations.Last().HasHigherPriority(newOperator) && 
                        !operations.Last().IsInBrackets && operations.Count != 1 && 
                        operations[operations.Count - 2].getMathOperator() != null) 
//////////////////////////LAST CONDITION ISN'T CERTAIN////////////////////////////////////////////
                    {
                        if (operations[operations.Count - 2].HasTheSamePriority(newOperator))
                        {
                            moveArgDown();
                            operations.Last().DoOperation();
                        }
                        else if (operations[operations.Count - 2].HasLowerPriority(newOperator))
                        {
                            operations.Last().setMathOperator(newOperator);
                        }
                        else //operations[operations.Count - 2].HasHigherPriority(newOperator) == true
                        {
                            moveArgDown();
                            operations.Last().DoOperation();
                        }
                    }

                    operations.Last().setMathOperator(newOperator);
                    return operations.Last().firstArgument ?? Double.MinValue;
                }
            }
          
        }

        public void LeftBracketService()
        {
            if(operations.Count != 0)
                operations.Add(new Operation(true));
        }

        public double RightBracketService(string numberString)
        {
            double numberDouble;

            if (!Double.TryParse(numberString, out numberDouble))
            {
                //throw an exception

                return Double.MinValue;
            }

            operations.Last().secondArgument = numberDouble;

                //doing operations in this brackets
            while (!operations.Last().IsInBrackets && operations.Count != 1)
            {
                operations.Last().DoOperation();
                moveArgDown();
            }  

            if(operations.Last().secondArgument != null)
                operations.Last().DoOperation();

            operations.Last().IsInBrackets = false;

            return operations.Last().firstArgument ?? Double.MinValue;
        }
        
        private void moveArgDown()
        {
            if (operations[operations.Count - 2].firstArgument != null)
                operations[operations.Count - 2].secondArgument = operations.Last().firstArgument;
            else
            {
                operations[operations.Count - 2].firstArgument = operations.Last().firstArgument;
                operations[operations.Count - 2].setMathOperator(operations.Last().getMathOperator());
            }

            operations.RemoveAt(operations.Count - 1);
        }
    }
}

