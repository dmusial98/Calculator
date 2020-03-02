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

        List<Double> results = new List<Double>();
        List<OperationStruct> operations = new List<OperationStruct>();

        bool isFirstOperation = true;

        double firstArgument;


        public Calculation(Controler con)
        {
            controler = con;
            results.Add(0.0);
            operations.Add(new OperationStruct(OperationStruct.Operation.None));
        }

        public double Count(string numberStr, OperationStruct newOperationStruct)
        {
            double numberDouble;

            if (!Double.TryParse(numberStr, out numberDouble))
            {
                return results[results.Count - 1];
            }

            if (isFirstOperation)
            {
                results[results.Count - 1] = numberDouble;
                operations[operations.Count - 1] = newOperationStruct;
                isFirstOperation = false;
            }
            else  //when calculator has second or later operator
            {
                if(newOperationStruct.priority == operations[operations.Count - 1].priority)
                {
                    firstArgument = results[results.Count - 1];
                    doOperation(operations[operations.Count - 1], ref firstArgument, numberDouble);
                    results[results.Count - 1] = firstArgument;

                    operations[operations.Count - 1] = newOperationStruct;
                }
                else if((newOperationStruct.priority < operations[operations.Count - 1].priority))
                {
                    firstArgument = results[results.Count - 1];
                    doOperation(operations[operations.Count - 1], ref firstArgument, numberDouble);
                    results[results.Count - 1] = firstArgument;


                    if (operations.Count > 1)
                    {
                        if (newOperationStruct.priority <= operations[operations.Count - 2].priority)
                        {
                            operations.RemoveAt(operations.Count - 1); //deleting last operator

                            if (operations[operations.Count - 1].priority >= newOperationStruct.priority)
                            {
                                firstArgument = results[results.Count - 2];
                                doOperation(operations[operations.Count - 1], ref firstArgument, results[results.Count - 1]);
                                results[results.Count - 2] = firstArgument;
                             
                                results.RemoveAt(results.Count - 1);
                            }
                            else
                            {
                                firstArgument = results[results.Count - 1];
                                doOperation(newOperationStruct, ref firstArgument, numberDouble);
                                results[results.Count - 1] = firstArgument;

                                results.RemoveAt(results.Count - 1);
                            }
                        }
                    }

                    if(operations.Count > 1)
                    {
                        if(operations[operations.Count - 2].priority == newOperationStruct.priority)
                        {
                            operations.RemoveAt(operations.Count - 1);

                            firstArgument = results[results.Count - 2];
                            doOperation(operations[operations.Count - 1], ref firstArgument, results[results.Count - 1]);
                            results[results.Count - 2] = firstArgument;
             
                            results.RemoveAt(results.Count - 1);
                        }
                    }
                    operations[operations.Count - 1] = newOperationStruct;
                }
                else
                {
                    results.Add(numberDouble);
                    operations.Add(newOperationStruct);
                }
            }
            return results[results.Count - 1];
        }

        private void doOperation(OperationStruct operationStruct, ref double firstArgument, double secondArgument)
        {
            switch(operationStruct.operation)
            {
                case OperationStruct.Operation.Add:
                    firstArgument += secondArgument;
                    break;

                case OperationStruct.Operation.Subtract:
                    firstArgument -= secondArgument;
                    break;

                case OperationStruct.Operation.Multiply:
                    firstArgument *= secondArgument;
                    break;

                case OperationStruct.Operation.Divide:
                    firstArgument /= secondArgument;
                    break;

                case OperationStruct.Operation.Power:
                    firstArgument = Math.Pow(firstArgument, secondArgument);
                    break;
            }
        }
    }
}

