using ExpressionTreeTask;
using NUnit.Framework;
using FluentAssertions;

namespace ExpressionTreeTests
{
    public class NumberNodeShould
    {
        private NumberNode _numberNode;

        [Test]
        public void CalculateCorrectly()
        {
            _numberNode = new NumberNode(42);

            _numberNode.Calculate().Should().Be(42);
        }

        [Test]
        public void PrintCorrectly()
        {
            _numberNode = new NumberNode(42);

            _numberNode.Print().Should().Be("42");
        }
    }
}