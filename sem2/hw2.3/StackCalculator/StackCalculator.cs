using System;

namespace StackCalculator
{
    /// <summary>
    /// Represents a calculator for executing expression in reverse polish notation.
    /// </summary>
    class StackCalculator
    {
        private readonly IStack _stack;

        /// <summary>
        /// Initializes a new instance of the StackCalculator class with the desirable stack.
        /// </summary>
        /// <param name="stack">The stack which the StackCalculator will use.</param>
        public StackCalculator(IStack stack)
        {
            this._stack = stack;
        }

        /// <summary>
        /// Removes and returns two elements from the top of the stack.
        /// </summary>
        /// <returns>Two elements removed from the top of the stack.</returns>
        private (double, double) GetTwoOperands()
        {
            if (_stack.Count < 2)
            {
                throw new Exception("Incorrect input string");
            }

            return (_stack.Pop(), _stack.Pop());
        }

        /// <summary>
        /// Executes the expression in reverse polish notation and print the result in the console.
        /// </summary>
        /// <param name="input">The expression in a string format.</param>
        public void ExecuteLine(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            var operandsAndOperations = input.Split(' ');
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
