using ExpressionTreeTask;
using FluentAssertions;
using NUnit.Framework;

namespace ExpressionTreeTests
{
    public class AdditionNodeShould
    {
        [Test]
        public void CalculateCorrectly()
        {
            var additionNode = new AdditionNode(new NumberNode(42), new NumberNode(54));

            additionNode.Calculate().Should().Be(96);
        }

        [Test]
        public void PrintCorrectly()
        {
            var additionNode = new AdditionNode(new NumberNode(42), new NumberNode(54));

            additionNode.Print().Should().Be("(+ 42 54)");
        }
    }
}