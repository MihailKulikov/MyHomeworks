using System;

namespace StackCalculator
{
    /// <summary>
    /// Represents a calculator for executing expression in reverse polish notation.
    /// </summary>
    public class Calculator
    {
        private readonly IStack _stack;

        /// <summary>
        /// Initializes a new instance of the StackCalculator class with the desirable stack.
        /// </summary>
        /// <param name="stack">The stack which the StackCalculator will use.</param>
        public Calculator(IStack stack)
        {
            _stack = stack;
        }

        /// <summary>
        /// Removes and returns two elements from the top of the stack.
        /// </summary>
        /// <returns>Two elements removed from the top of the stack.</returns>
        private (double, double) GetTwoOperands()
        {
            if (_stack.Count < 2)
            {
                throw new InvalidInputExpressionException("The entered expression has an invalid format.");
            }

            return (_stack.Pop(), _stack.Pop());
        }

        /// <summary>
        /// Executes the expression in reverse polish notation and print the result in the console.
        /// </summary>
        /// <param name="input">The expression in a string format.</param>
        public double ExecuteLine(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            
            var operandsAndOperations = input.Split(' ');
            foreach (var item in operandsAndOperations)
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
                                var (first, second) = GetTwoOperands();
                                _stack.Push(second + first);
                                break;
                            }
                        case "-":
                            {
                                var (first, second) = GetTwoOperands();
                                _stack.Push(second - first);
                                break;
                            }
                        case "*":
                            {
                                var (first, second) = GetTwoOperands();
                                _stack.Push(first * second);
                                break;
                            }
                        case "/":
                            {
                                var(first, second) = GetTwoOperands();
                                if (first == 0)
                                    throw new DivideByZeroException("Divide by zero happen.");
                                
                                _stack.Push(second / first);
                                break;
                            }
                        default:
                        {
                            throw new InvalidInputExpressionException("The entered expression has an invalid format.");
                        }
                    }
                }
            }
            
            if (_stack.Count != 1)
            {
                throw new InvalidInputExpressionException("The entered expression has an invalid format.");
            }
            
            return _stack.Pop();
        }
    }
}
