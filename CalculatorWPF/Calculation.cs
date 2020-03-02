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
                    switch (operations[operations.Count - 1].operation)
                    {
                        case OperationStruct.Operation.Add:
                            results[results.Count - 1] += numberDouble;
                            break;

                        case OperationStruct.Operation.Subtract:
                            results[results.Count - 1] -= numberDouble;
                            break;

                        case OperationStruct.Operation.Multiply:
                            results[results.Count - 1] *= numberDouble;
                            break;

                        case OperationStruct.Operation.Divide:
                            results[results.Count - 1] /= numberDouble;
                            break;

                        case OperationStruct.Operation.Power:
                            results[results.Count - 1] = Math.Pow(results[results.Count - 1], numberDouble);
                            break;
                    }

                    operations[operations.Count - 1] = newOperationStruct;
                }
                else if((newOperationStruct.priority < operations[operations.Count - 1].priority))
                {
                    switch(operations[operations.Count - 1].operation)
                    {
                        case OperationStruct.Operation.Add:
                            results[results.Count - 1] += numberDouble;
                        break;

                        case OperationStruct.Operation.Subtract:
                            results[results.Count - 1] -= numberDouble;
                        break;

                        case OperationStruct.Operation.Multiply:
                            results[results.Count - 1] *= numberDouble;
                        break;

                        case OperationStruct.Operation.Divide:
                            results[results.Count - 1] /= numberDouble;
                        break;

                        case OperationStruct.Operation.Power:
                            results[results.Count - 1] = Math.Pow(results[results.Count - 1], numberDouble);
                            break;
                    }



                    if (operations.Count > 1)
                    {
                        if (newOperationStruct.priority <= operations[operations.Count - 2].priority)
                        {
                            operations.RemoveAt(operations.Count - 1); //deleting last operator

                            if (operations[operations.Count - 1].priority >= newOperationStruct.priority)
                            {
                                switch (operations[operations.Count - 1].operation)
                                {
                                    case OperationStruct.Operation.Add:
                                        results[results.Count - 2] += results[results.Count - 1];
                                        break;

                                    case OperationStruct.Operation.Subtract:
                                        results[results.Count - 2] -= results[results.Count - 1];
                                        break;

                                    case OperationStruct.Operation.Multiply:
                                        results[results.Count - 2] *= results[results.Count - 1];
                                        break;

                                    case OperationStruct.Operation.Divide:
                                        results[results.Count - 2] /= results[results.Count - 1];
                                        break;

                                    case OperationStruct.Operation.Power:
                                        results[results.Count - 2] = Math.Pow(results[results.Count - 2], results[results.Count - 1]);
                                        break;
                                }

                                results.RemoveAt(results.Count - 1);
                            }
                            else
                            {
                                switch (newOperationStruct.operation)
                                {
                                    case OperationStruct.Operation.Add:
                                        results[results.Count - 1] += numberDouble;
                                        break;

                                    case OperationStruct.Operation.Subtract:
                                        results[results.Count - 1] -= numberDouble;
                                        break;

                                    case OperationStruct.Operation.Multiply:
                                        results[results.Count - 1] *= numberDouble;
                                        break;

                                    case OperationStruct.Operation.Divide:
                                        results[results.Count - 1] /= numberDouble;
                                        break;

                                    case OperationStruct.Operation.Power:
                                        results[results.Count - 1] = Math.Pow(results[results.Count - 1], numberDouble);
                                        break;
                                }

                                results.RemoveAt(results.Count - 1);
                            }
                        }
                    }

                    if(operations.Count > 1)
                    {
                        if(operations[operations.Count - 2].priority == newOperationStruct.priority)
                        {
                            operations.RemoveAt(operations.Count - 1);

                            switch (operations[operations.Count - 1].operation)
                            {
                                case OperationStruct.Operation.Add:
                                    results[results.Count - 2] += results[results.Count - 1];
                                    break;

                                case OperationStruct.Operation.Subtract:
                                    results[results.Count - 2] -= results[results.Count - 1];
                                    break;

                                case OperationStruct.Operation.Multiply:
                                    results[results.Count - 2] *= results[results.Count - 1];
                                    break;

                                case OperationStruct.Operation.Divide:
                                    results[results.Count - 2] /= results[results.Count - 1];
                                    break;

                                case OperationStruct.Operation.Power:
                                    results[results.Count - 2] = Math.Pow(results[results.Count - 2], results[results.Count - 1]);
                                    break;
                            }

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

        private void doOperation(OperationStruct operationStruct, ref double firstArgument, ref double secondArgument)
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
                    results[results.Count - 1] = Math.Pow(firstArgument, secondArgument);
                    break;
            }
        }

    }
}

