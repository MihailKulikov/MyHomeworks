using System;

namespace StackCalculator
{
    class StackCalculator
    {
        private readonly IStack _stack;
        
        public StackCalculator(IStack stack)
        {
            this._stack = stack;
        }

        private (double, double) GetTwoOperands()
        {
            if (_stack.Count < 2)
            {
                throw new Exception("Incorrect input string");
            }

            return (_stack.Pop(), _stack.Pop());
        }

        public void ExecuteLine(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            string[] operandsAndOperations = input.Split(' ');
            foreach(var item in operandsAndOperations)
            {
                if (double.TryParse(item, out double number))
                {
                    _stack.Push(number);
                }
                else
                {
                    switch(item)
                    {
                        case "+":
                            {
                                var operands = GetTwoOperands();
                                _stack.Push(operands.Item2 + operands.Item1);
                                break;
                            }
                        case "-":
                            {
                                var operands = GetTwoOperands();
                                _stack.Push(operands.Item2 - operands.Item1);
                                break;
                            }
                        case "*":
                            {
                                var operands = GetTwoOperands();
                                _stack.Push(operands.Item2 * operands.Item1);
                                break;
                            }
                        case "/":
                            {
                                var operands = GetTwoOperands();
                                _stack.Push(operands.Item2 / operands.Item1);
                                break;
                            }
                        default:
                            {
                                throw new Exception("Incorrect input string.");
                            }
                    }
                }
            }
            if (_stack.Count != 1)
            {
                throw new Exception("Incorrect input string.");
            }

            Console.WriteLine(_stack.Pop());
        }
    }
}
