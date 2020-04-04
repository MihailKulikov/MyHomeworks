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
    }
}