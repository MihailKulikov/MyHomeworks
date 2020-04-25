using System;
using System.Collections.Generic;

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
            var tokens = new Queue<string>(expression.Replace("(", "").Replace(")", "")
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));
            
            return GetTree(tokens);
        }

        private static INode GetTree(Queue<string> tokens)
        {
            var newToken = tokens.Dequeue();

            if (int.TryParse(newToken, out var number))
            {
                return new NumberNode(number);
            }

            return newToken switch
            {
                "+" => new AdditionNode(GetTree(tokens), GetTree(tokens)),
                "-" => new SubtractionNode(GetTree(tokens), GetTree(tokens)),
                "*" => new MultiplicationNode(GetTree(tokens), GetTree(tokens)),
                "/" => new DivisionNode(GetTree(tokens), GetTree(tokens)),
                _ => throw new InvalidInputExpressionException("Unknown operation.")
            };
        }
    }
}
