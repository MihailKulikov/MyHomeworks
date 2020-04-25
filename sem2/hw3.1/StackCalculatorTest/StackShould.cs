using System;
using NUnit.Framework;
using StackCalculator;
using FluentAssertions;

namespace StackCalculatorTest
{
    [TestFixture("with array")]
    [TestFixture("with list")]
    public class StackShould
    {
        private IStack _stack;
        private const double FirstElement = 42.42;
        private const double SecondElement = 19.01;
        private readonly string _stackType;
        
        public StackShould(string stackType)
        {
            this._stackType = stackType;
            _stack = stackType switch
            {
                "with array" => new StackWithArray(),
                "with list" => new StackWithList(),
            };
        }

        [TearDown]
        public void TearDown()
        {
            _stack = _stackType switch
            {
                "with array" => new StackWithArray(),
                "with list" => new StackWithList()
            };
        }
        
        [Test]
        public void BeEmptyAfterCreation()
        {
            _stack.Count.Should().Be(0);
        }

        [Test]
        public void Throw_InvalidOperationException_AfterPopEmptyStack()
        {
            _stack.Invoking(x => x.Pop())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Stack is empty.");
        }

        [Test]
        public void PopElement_AfterPush()
        {
            _stack.Push(FirstElement);
            
            _stack.Pop().Should().Be(FirstElement);
        }

        [Test]
        public void IncrementCount_AfterPush()
        {
            _stack.Push(FirstElement);
        
            _stack.Count.Should().Be(1);
        }

        [Test]
        public void DecrementCount_AfterPop()
        {
            _stack.Push(FirstElement);
            _stack.Pop();
            
            _stack.Count.Should().Be(0);
        }

        [Test]
        public void Be_LastIn_FirstOut_Collection()
        {
            _stack.Push(FirstElement);
            _stack.Push(SecondElement);

            _stack.Pop().Should().Be(SecondElement);
            _stack.Pop().Should().Be(FirstElement);
        }
    }
}