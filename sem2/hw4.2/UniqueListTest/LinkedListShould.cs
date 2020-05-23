using System;
using FluentAssertions;
using NUnit.Framework;
using UniqueListRealisation;

namespace UniqueListTest
{
    [TestFixture("LinkedList")]
    [TestFixture("UniqueList")]
    public class LinkedListShould
    {
        private LinkedList<string> _linkedList;
        private readonly string _listType;
        
        public LinkedListShould(string listType)
        {
            this._listType = listType;
        }

        [SetUp]
        public void Setup()
        {
            _linkedList = _listType switch
            {
                "LinkedList" => new LinkedList<string>(),
                "UniqueList" => new UniqueList<string>()
            };
        }

        [Test]
        public void BeEmptyAfterCreation()
        {
            _linkedList.Should().BeEmpty();
        }

        [Test]
        public void Throw_ArgumentOutOfRangeException_ThenTryAddItemWithWrongIndex()
        {
            _linkedList.Invoking(x => x.AddElementByIndex("42", 2))
                .Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Throw_ArgumentNullException_ThenTryAddNull()
        {
            _linkedList.Invoking(x => x.AddElementByIndex(null, 0))
                .Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void AddItemToTheEnd()
        {
            _linkedList.AddElementByIndex("42", 0);
            _linkedList.AddElementByIndex("84", 1);
            _linkedList.AddElementByIndex("168", 2);
            _linkedList.AddElementByIndex("336", 3);

            _linkedList.Should().Equal("42", "84", "168", "336");
        }

        [Test]
        public void AddItemToTop()
        {
            _linkedList.AddElementByIndex("42", 0);
            _linkedList.AddElementByIndex("84", 0);
            _linkedList.AddElementByIndex("168", 0);
            _linkedList.AddElementByIndex("336", 0);

            _linkedList.Should().Equal("336", "168", "84", "42");
        }

        [Test]
        public void AddItemToMiddle()
        {
            _linkedList.AddElementByIndex("42", 0);
            _linkedList.AddElementByIndex("84", 1);

            _linkedList.AddElementByIndex("168", 1);
            _linkedList.AddElementByIndex("336", 1);

            _linkedList.Should().Equal("42", "336", "168", "84");
        }

        [Test]
        public void Throw_ArgumentNullException_ThenTryToCheck_if_NullItem_Is_In_LinkedList()
        {
            _linkedList.Invoking(x => x.Contains(null))
                .Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ReturnTrue_If_Item_Is_In_LinkedList()
        {
            _linkedList.AddElementByIndex("42", 0);

            _linkedList.Contains("42").Should().Be(true);
        }

        [Test]
        public void ReturnFalse_If_Item_Is_Not_In_LinkedList()
        {
            _linkedList.Contains("42").Should().Be(false);
        }

        [Test]
        public void Throw_ArgumentNullException_ThenTryRemovesNull()
        {
            _linkedList.Invoking(x => x.Remove(null))
                .Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Remove_FirstItem()
        {
            _linkedList.AddElementByIndex("42", 0);
            _linkedList.AddElementByIndex("84", 1);
            _linkedList.AddElementByIndex("168", 2);
            _linkedList.AddElementByIndex("336", 3);

            _linkedList.Remove("42");

            _linkedList.Should().Equal("84", "168", "336");
        }

        [Test]
        public void Remove_LastItem()
        {
            _linkedList.AddElementByIndex("42", 0);
            _linkedList.AddElementByIndex("84", 1);
            _linkedList.AddElementByIndex("168", 2);
            _linkedList.AddElementByIndex("336", 3);

            _linkedList.Remove("336");

            _linkedList.Should().Equal("42", "84", "168");
        }

        [Test]
        public void Remove_MiddleItem()
        {
            _linkedList.AddElementByIndex("42", 0);
            _linkedList.AddElementByIndex("84", 1);
            _linkedList.AddElementByIndex("168", 2);
            _linkedList.AddElementByIndex("336", 3);

            _linkedList.Remove("84");
            _linkedList.Remove("168");

            _linkedList.Should().Equal("42", "336");
        }

        [Test]
        public void AddItemsCorrectly_AfterRemovingFirstItem()
        {
            _linkedList.AddElementByIndex("42", 0);
            _linkedList.AddElementByIndex("84", 1);
            _linkedList.AddElementByIndex("168", 2);
            _linkedList.AddElementByIndex("336", 3);

            _linkedList.Remove("42");
            _linkedList.AddElementByIndex("35", 0);
            _linkedList.AddElementByIndex("25", 1);

            _linkedList.Should().Equal("35", "25", "84", "168", "336");
        }

        [Test]
        public void AddItemsCorrectly_AfterRemovingLastItem()
        {
            _linkedList.AddElementByIndex("42", 0);
            _linkedList.AddElementByIndex("84", 1);
            _linkedList.AddElementByIndex("168", 2);
            _linkedList.AddElementByIndex("336", 3);

            _linkedList.Remove("336");
            _linkedList.AddElementByIndex("1", 3);
            _linkedList.AddElementByIndex("2", 3);

            _linkedList.Should().Equal("42", "84", "168", "2", "1");
        }
    }
}