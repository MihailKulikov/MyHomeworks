using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using HashTableTask;
using NUnit.Framework;

namespace HashTableTaskTests
{
    public class HashTableShould
    {
        private HashTable _hashTable;
        private IHashFunction _hashFunction;
        
        [SetUp]
        public void SetUp()
        {
            _hashFunction = new StandardHashFunction();
            _hashTable = new HashTable(new StringWriter(), _hashFunction);
        }

        private (string, string) GenerateTwoDifferentStringsWithTheSameHashCode()
        {
            var words = new Dictionary<int, string>();

            var i = 0;
            string tempString;
            while (true)
            {
                i++;
                tempString = i.ToString();
                try
                {
                    words.Add(_hashFunction.GetHashCode(tempString), tempString);
                }
                catch (Exception)
                {
                    break;
                }
            }

            var collisionHash = _hashFunction.GetHashCode(tempString);

            return (words[collisionHash], tempString);
        }
        
        [Test]
        public void BeEmptyAfterCreation()
        {
            _hashTable.Should().BeEmpty();
        }

        [Test]
        public void Throw_ArgumentNullException_When_TryToAddNull()
        {
            _hashTable.Invoking(x => x.Add(null))
                .Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void AddItemThat_Is_Not_In_The_HashTable()
        {
            _hashTable.Add("42");

            _hashTable.Should().BeEquivalentTo("42");
        }

        [Test]
        public void NotAddItemThat_Is_In_The_HashTable()
        {
            _hashTable.Add("42");
            
            _hashTable.Add("42");

            _hashTable.Should().BeEquivalentTo("42");
        }

        [Test]
        public void Throw_ArgumentNullException_When_TryToRemoveNull()
        {
            _hashTable.Invoking(x => x.Remove(null))
                .Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void RemoveItem_That_Is_In_The_HashTable()
        {
            _hashTable.Add("42");
            _hashTable.Add("84");
            
            _hashTable.Remove("84");

            _hashTable.Should().BeEquivalentTo("42");
        }

        [Test]
        public void NotFall_AfterTryToRemoveItem_That_Is_Not_In_The_HashTable()
        {
            _hashTable.Add("42");
            
            _hashTable.Remove("84");

            _hashTable.Should().BeEquivalentTo("42");
        }

        [Test]
        public void AddItem_After_Removing_It()
        {
            _hashTable.Add("42");
            
            _hashTable.Remove("42");
            _hashTable.Add("42");

            _hashTable.Should().BeEquivalentTo("42");
        }

        [Test]
        public void ReturnTrue_When_It_Checks_For_The_Presence_Of_An_Item_That_Is_In_The_Table()
        {
            _hashTable.Add("42");

            _hashTable.IsContains("42").Should().Be(true);
        }

        [Test]
        public void ReturnFalse_When_It_Checks_For_The_Presence_Of_An_Item_That_Is_Not_In_The_Table()
        {
            _hashTable.Add("42");

            _hashTable.IsContains("84").Should().Be(false);
        }

        [Test]
        public void AddTwoDifferentStrings_With_TheSameHashCode()
        {
            var (firstString, secondString) = GenerateTwoDifferentStringsWithTheSameHashCode();
            
            _hashTable.Add(firstString);
            _hashTable.Add(secondString);

            _hashTable.Should().BeEquivalentTo(firstString, secondString);
        }

        [Test]
        public void ChangeHashFunction_And_NotLoseData()
        {
            _hashTable.Add("42");
            _hashTable.Add("1901");
            _hashTable.Add("2001");
            
            _hashTable.ChangeHashFunction(new PolynomialRollingHashFunction());

            _hashTable.Should().BeEquivalentTo("42", "1901", "2001");
        }

        [Test]
        public void ChangeHashFunction_And_AddCorrectly()
        {
            _hashTable.Add("42");
            
            _hashTable.ChangeHashFunction(new PolynomialRollingHashFunction());
            _hashTable.Add("84");

            _hashTable.Should().BeEquivalentTo("42", "84");
        }

        [Test]
        public void ChangeHashFunction_And_NotAddItemThat_Is_In_HashTable()
        {
            _hashTable.Add("42");
            
            _hashTable.ChangeHashFunction(new PolynomialRollingHashFunction());
            _hashTable.Add("42");

            _hashTable.Should().BeEquivalentTo("42");
        }

        [Test]
        public void ChangeHashFunction_And_RemoveItem_That_Is_In_The_HashTable()
        {
            _hashTable.Add("42");
            
            _hashTable.ChangeHashFunction(new PolynomialRollingHashFunction());
            _hashTable.Remove("42");

            _hashTable.Should().BeEmpty();
        }

        [Test]
        public void ChangeHashFunction_And_NotFall_AfterRemovingItem_That_Is_Not_In_The_HashTable()
        {
            _hashTable.Add("42");
            
            _hashTable.ChangeHashFunction(new PolynomialRollingHashFunction());
            _hashTable.Remove("84");

            _hashTable.Should().BeEquivalentTo("42");
        }

        [Test]
        public void ChangeHashFunction_And_ReturnTrue_When_It_Checks_For_The_Presence_Of_An_Item_That_Is_In_The_Table()
        {
            _hashTable.Add("42");
            
            _hashTable.ChangeHashFunction(new PolynomialRollingHashFunction());

            _hashTable.IsContains("42").Should().Be(true);
        }

        [Test]
        public void
            ChangeHashFunction_And_ReturnFalse_When_It_Checks_For_The_Presence_Of_An_Item_That_Is_Not_In_The_Table()
        {
            _hashTable.Add("42");
            
            _hashTable.ChangeHashFunction(new PolynomialRollingHashFunction());

            _hashTable.IsContains("84").Should().Be(false);
        }

        [Test]
        public void NotRemoveString_With_SameHashCode()
        {
            var (firstString, secondString) = GenerateTwoDifferentStringsWithTheSameHashCode();
            _hashTable.Add(firstString);
            
            _hashTable.Remove(secondString);

            _hashTable.Should().BeEquivalentTo(firstString);
        }

        [Test]
        public void ReturnFalse_When_It_Checks_For_The_Presence_Of_An_String_With_SameHashCode()
        {
            var (firstString, secondString) = GenerateTwoDifferentStringsWithTheSameHashCode();
            _hashTable.Add(firstString);

            _hashTable.IsContains(secondString).Should().Be(false);
        }
    }
}