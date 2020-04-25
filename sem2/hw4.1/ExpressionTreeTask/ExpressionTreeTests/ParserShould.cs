using ExpressionTreeTask;
using FluentAssertions;
using NUnit.Framework;

namespace ExpressionTreeTests
{
    public class ParserShould
    {
        private Parser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new Parser();
        }

        [Test]
        public void Build_Correctly_Tree_From_SingleNumber()
        {
            var tree = Parser.BuildTree("42");

            tree.Calculate().Should().Be(42);
        }
        
        [TestCase("-42", -42)]
        [TestCase("(* (+ 1 1) -2)", -4)]
        [TestCase("(+ (/ (* (+ 1 -10) (- 3 (/ -10 5))) -1) (- -5 -3))", 43) ]
        [Test]
        public void Build_Correctly_Tree_From_Expression_With_UnaryMinus(string expression, int result)
        {
            var tree = Parser.BuildTree(expression);

            tree.Calculate().Should().Be(result);
        }

        [Test]
        public void Throw_InvalidInputExpressionException_If_ExpressionContains_UnknownOperation()
        {
            _parser.Invoking(x => Parser.BuildTree("(^ 3 (% 5 3))"))
                .Should().Throw<InvalidInputExpressionException>().WithMessage("Unknown operation.");
        }

        [TestCase("1 + 2 * 3")]
        [TestCase("* 5 3")]
        [TestCase("5 3 4489")]
        [TestCase("pwerthht")]
        [Test]
        public void Throw_InvalidInputExpressionException_If_Expression_Is_Incorrect(string expression)
        {
            _parser.Invoking(x => Parser.BuildTree(expression))
                .Should().Throw<InvalidInputExpressionException>();
        }

        [TestCase("(* (+ 1 1) 2)", 4)]
        [TestCase("(+ (/ (* (+ 1 10) (- 3 (/ 10 5))) 11) (- 5 3))", 3)]
        [TestCase("(* (+ 1 10) (- 3 (/ 10 5)))",11)]
        [Test]
        public void BuildCorrectlyTree_If_Expression_Is_Correct(string expression, int result)
        {
            Parser.BuildTree(expression).Calculate().Should().Be(result);
        }
    }
}