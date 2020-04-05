using HashTable;
using NUnit.Framework;
using FluentAssertions;

namespace HashTableTaskTests
{
    [TestFixture("Polynomial Rolling")]
    [TestFixture("StandardHashFunction")]
    public class HashFunctionShould
    {
        private const string InputString = "abc";
        
        private readonly IHashFunction _hashFunction;

        public HashFunctionShould(string hashFunctionType)
        {
            _hashFunction = hashFunctionType switch
            {
                "Polynomial Rolling" => new PolynomialRollingHashFunction(),
                "StandardHashFunction" => new StandardHashFunction()
            };
        }
        
        [Test]
        public void Returns_SameHashCode_FromSameString()
        {
            var inputStringCopy = (string)InputString.Clone();

            _hashFunction.GetHashCode(InputString).Should().Be(_hashFunction.GetHashCode(inputStringCopy));
        }
    }
}