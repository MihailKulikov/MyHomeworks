using ExpressionTreeTask;
using FluentAssertions;
using NUnit.Framework;

namespace ExpressionTreeTests
{
    public class DivisionNodeShould
    {
        [Test]
        public void CalculateCorrectly()
        {
            var divisionNode = new DivisionNode(new NumberNode(50),new NumberNode(10));

            divisionNode.Calculate().Should().Be(5);
        }

        [Test]
        public void PrintCorrectly()
        {
            var divisionNode = new DivisionNode(new NumberNode(54),new NumberNode(42));

            divisionNode.Print().Should().Be("(/ 54 42)");
        }
    }
}