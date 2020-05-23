using ExpressionTreeTask;
using FluentAssertions;
using NUnit.Framework;

namespace ExpressionTreeTests
{
    public class MultiplicationNodeShould
    {
        [Test]
        public void CalculateCorrectly()
        {
            var multiplicationNode = new MultiplicationNode(new NumberNode(6),new NumberNode(7));

            multiplicationNode.Calculate().Should().Be(42);
        }

        [Test]
        public void PrintCorrectly()
        {
            var multiplicationNode = new MultiplicationNode(new NumberNode(6), new NumberNode(7));

            multiplicationNode.Print().Should().Be("(* 6 7)");
        }
    }
}