using ExpressionTreeTask;
using FluentAssertions;
using NUnit.Framework;

namespace ExpressionTreeTests
{
    public class SubtractionNodeShould
    {
        [Test]
        public void CalculateCorrectly()
        {
            var subtractionNode = new SubtractionNode(new NumberNode(54), new NumberNode(42));

            subtractionNode.Calculate().Should().Be(12);
        }

        [Test]
        public void PrintCorrectly()
        {
            var subtractionNode = new SubtractionNode(new NumberNode(54), new NumberNode(42));

            subtractionNode.Print().Should().Be("(- 54 42)");
        }
    }
}