using System;
using FluentAssertions;
using NUnit.Framework;
using StackCalculator;

namespace StackCalculatorTest
{
    [TestFixture]
    public class CalculatorExecuteLineShould
    {
        private Calculator _calculator;
        private IStack _stack;
        [SetUp]
        public void Setup()
        {
            _stack = new StackWithList();
            _calculator = new Calculator(_stack);
        }

        [TearDown]
        public void TearDown()
        {
            Setup();
        }

        [Test] 
        public void Throw_ArgumentNullException()
        {
            _calculator.Invoking(x => x.ExecuteLine(null))
                .Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ReturnInputSingleNumber()
        {
            _calculator.ExecuteLine("12,5").Should().Be(12.5);
        }
        
        [Test]
        public void Sum_TwoNumbers_Correctly()
        {
            _calculator.ExecuteLine("1,2 2,5 +").Should().Be(3.7);
        }

        [Test]
        public void Subtract_TwoNumbers_Correctly()
        {
            _calculator.ExecuteLine("1,2 2,5 -").Should().Be(-1.3);
        }

        [Test]
        public void Multiply_TwoNumbers_Correctly()
        {
            _calculator.ExecuteLine("3,5 6,7 *").Should().Be(23.45);
        }

        [Test]
        public void Divide_TwoNumbers_Correctly()
        {
            _calculator.ExecuteLine("34 5 /").Should().Be(6.8);
        }

        [Test]
        public void Throw_DivideByZeroException_With_CorrectMessage_If_There_HasBeen_a_DivisionByZero()
        {
            _calculator.Invoking(x => x.ExecuteLine("1 0 /"))
                .Should().Throw<DivideByZeroException>().WithMessage("Divide by zero happen.");
        }

        [TestCase("1 2 + 3 - 4 + 5 - 6 +", 5)]
        [TestCase("1 2 * 3 12 * 4 / - 789 -", -796)]
        [TestCase("7 7 + 7 7 / 7 * -", 7)]
        [Test]
        public void CalculateCorrectly_CorrectExpressions(string expression, double result)
        {
            _calculator.ExecuteLine(expression).Should().Be(result);
        }

        [TestCase("12 - 12 - - 122 + 10293 -")]
        [TestCase("223 12 - 222 + 122 * * 122")]
        [TestCase("222 1111 + 222 - 23334 * 122 / 1212 - -")]
        [TestCase("1 2 + 3 - 4 + 5 - 6 + +")]
        [TestCase("1 2 + 3 - 4 + 5 - 6 + + =")]
        [TestCase("abc")]
        [TestCase("1 2 * 3 12a * 4 / - 789 -")]
        [TestCase("12 13 + 5")]
        [Test]
        public void Throw_InvalidInputExpressionException_When_Expression_Is_Incorrect(string expression)
        {
            _calculator.Invoking(x => x.ExecuteLine(expression))
                .Should().Throw<InvalidInputExpressionException>();
        }
    }
}