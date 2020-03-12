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

        public Calculation(Controler con)
        { }

        public double Count(string numberString, MathOperator newOperator)
        {
            double numberDouble;

            if (!Double.TryParse(numberString, out numberDouble))
            {
                //throw an exception

                return 0.0;
            }

            if (operations.Count == 0)
            {
                operations.Add(new Operation(newOperator, numberDouble));
                return numberDouble;
            }
            else //operations.Count > 0
            {
                //the same priority
                if(operations.Last().HasTheSamePriority(newOperator))
                {
                    operations.Last().secondArgument = numberDouble;
                    double result = operations.Last().DoOperation();
                    operations.Last().setMathOperator(newOperator);

                    return result;
                }
                //lower priority old operator's
                else if(operations.Last().HasLowerPriority(newOperator))
                {
                    operations.Add(new Operation(newOperator, numberDouble));
                    return numberDouble;
                }
                //higher priority old operator's
                else
                {
                    operations.Last().secondArgument = numberDouble;
                    operations.Last().DoOperation();

                    while (operations.Last().HasHigherPriority(newOperator) && operations.Count != 1)
                    {
                        if (operations[operations.Count - 2].HasTheSamePriority(newOperator))
                        {
                            operations[operations.Count - 2].secondArgument = operations.Last().firstArgument;
                            operations.RemoveAt(operations.Count - 1);
                            operations.Last().DoOperation();
                        }
                        else if(operations[operations.Count - 2].HasLowerPriority(newOperator))
                        {
                            operations.Last().setMathOperator(newOperator);
                        }
                        else //operations[operations.Count - 2].HasHigherPriority(newOperator) == true
                        {
                            operations[operations.Count - 2].secondArgument = operations.Last().firstArgument;
                            operations.RemoveAt(operations.Count - 1);
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
            operations.Add(new Operation());
        }

        public double RightBracketService()
        {


            return 0.0;
        }

        //public double Count(string numberStr, OperationStruct newOperationStruct)
        //{
        //    double numberDouble;

        //    if (!Double.TryParse(numberStr, out numberDouble))
        //    {
        //        return results[results.Count - 1];
        //    }

        //    if (isFirstOperation)
        //    {
        //        results[results.Count - 1] = numberDouble;
        //        operations[operations.Count - 1] = newOperationStruct;
        //        isFirstOperation = false;
        //    }
        //    else  //when calculator has second or later operator
        //    {
        //        //the same priority
        //        if(newOperationStruct.priority == operations[operations.Count - 1].priority)
        //        {
        //            firstArgument = results[results.Count - 1];
        //            doOperation(operations[operations.Count - 1], ref firstArgument, numberDouble);
        //            results[results.Count - 1] = firstArgument;

        //            operations[operations.Count - 1] = newOperationStruct;
        //        }
        //            //less priority
        //        else if((newOperationStruct.priority < operations[operations.Count - 1].priority))
        //        {
        //            firstArgument = results[results.Count - 1];
        //            doOperation(operations[operations.Count - 1], ref firstArgument, numberDouble);
        //            results[results.Count - 1] = firstArgument;


        //            if (operations.Count > 1)
        //            {
        //                if (newOperationStruct.priority <= operations[operations.Count - 2].priority)
        //                {
        //                    operations.RemoveAt(operations.Count - 1); //deleting last operator

        //                    if (operations[operations.Count - 1].priority >= newOperationStruct.priority)
        //                    {
        //                        firstArgument = results[results.Count - 2];
        //                        doOperation(operations[operations.Count - 1], ref firstArgument, results[results.Count - 1]);
        //                        results[results.Count - 2] = firstArgument;

        //                        results.RemoveAt(results.Count - 1);
        //                    }
        //                    else
        //                    {
        //                        firstArgument = results[results.Count - 1];
        //                        doOperation(newOperationStruct, ref firstArgument, numberDouble);
        //                        results[results.Count - 1] = firstArgument;

        //                        results.RemoveAt(results.Count - 1);
        //                    }
        //                }
        //            }

        //            if(operations.Count > 1)
        //            {
        //                if(operations[operations.Count - 2].priority == newOperationStruct.priority)
        //                {
        //                    operations.RemoveAt(operations.Count - 1);

        //                    firstArgument = results[results.Count - 2];
        //                    doOperation(operations[operations.Count - 1], ref firstArgument, results[results.Count - 1]);
        //                    results[results.Count - 2] = firstArgument;

        //                    results.RemoveAt(results.Count - 1);
        //                }
        //            }
        //            operations[operations.Count - 1] = newOperationStruct;
        //        }
        //            //higher priority
        //        else
        //        {
        //            results.Add(numberDouble);
        //            operations.Add(newOperationStruct);
        //        }
        //    }
        //    return results[results.Count - 1];
        //}

        //private void doOperation(OperationStruct operationStruct, ref double firstArgument, double secondArgument)
        //{
        //    switch(operationStruct.operation)
        //    {
        //        case OperationStruct.Operation.Add:
        //            firstArgument += secondArgument;
        //            break;

        //        case OperationStruct.Operation.Subtract:
        //            firstArgument -= secondArgument;
        //            break;

        //        case OperationStruct.Operation.Multiply:
        //            firstArgument *= secondArgument;
        //            break;

        //        case OperationStruct.Operation.Divide:
        //            firstArgument /= secondArgument;
        //            break;

        //        case OperationStruct.Operation.Power:
        //            firstArgument = Math.Pow(firstArgument, secondArgument);
        //            break;
        //    }
        //}
        
    }
}

