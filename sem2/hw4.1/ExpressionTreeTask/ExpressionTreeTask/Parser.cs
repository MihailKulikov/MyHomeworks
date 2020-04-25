using System.Data;

namespace ExpressionTreeTask
{
    /// <summary>
    /// Represents parser. Provides methods to build expression tree from expression in prefix notation.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Build expression tree from introduced expression in prefix notation.
        /// </summary>
        /// <param name="expression">Expression in prefix notation.</param>
        /// <returns>Root of the expression tree.</returns>
        public static INode BuildTree(string expression)
        {
            if (int.TryParse(expression, out var number))
                return new NumberNode(number);

            expression = expression.Remove(0, 1);
            expression = expression.Remove(expression.Length - 1, 1);
            var typeOfOperation = expression[0];
            expression = expression.Remove(0, 1);
            if (expression[0] == ' ')
                expression = expression.Remove(0, 1);

            var (firstOperand, secondOperand) = GetTwoOperands(expression);

            return typeOfOperation switch
            {
                '+' => new AdditionNode(BuildTree(firstOperand), BuildTree(secondOperand)),
                '-' => new SubtractionNode(BuildTree(firstOperand), BuildTree(secondOperand)),
                '*' => new MultiplicationNode(BuildTree(firstOperand), BuildTree(secondOperand)),
                '/' => new DivisionNode(BuildTree(firstOperand), BuildTree(secondOperand)),
                _ => throw new InvalidInputExpressionException("Unknown operation.")
            };
        }

        private static (string, string) GetTwoOperands(string expression)
        {
            if (char.IsDigit(expression[0]) || expression[0] == '-')
            {
                var i = 1;
                while (expression[i] != ' ' && expression[i] != '(' && i < expression.Length - 1)
                {
                    if (!char.IsDigit(expression[i]))
                        throw new InvalidInputExpressionException("The entered expression has an invalid format.");

                    i++;
                }

                var firstOperand = expression.Substring(0, i);
                expression = expression.Remove(0, i);
                if (expression[0] == ' ')
                    expression = expression.Remove(0, 1);

                return (firstOperand, expression);
            }

            if (expression[0] != '(')
                throw new InvalidInputExpressionException("The entered expression has an invalid format.");

            var count = 1;
            for (var i = 1; i < expression.Length - 1; i++)
            {
                if (expression[i] == '(')
                    count++;

                if (expression[i] == ')')
                    count--;

                if (count != 0) continue;
                    
                var firstOperand = expression.Substring(0, i + 1);
                expression = expression.Remove(0, i + 1);
                if (expression[0] == ' ')
                    expression = expression.Remove(0, 1);

                return (firstOperand, expression);
            }
            
            throw new InvalidExpressionException("The entered expression has an invalid format.");
        }
    }
}
