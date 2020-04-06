using System;
using NUnit.Framework;
using UniqueListRealisation;
using FluentAssertions;

namespace UniqueListTest
{
    public class Tests
    {
        [Test]
        public void BeEmptyAfterCreation()
        {
            var uniqueList = new UniqueList<string>();

            uniqueList.Should().BeEmpty();
        }

        [Test]
        public void SetCapacity_From_Constructor()
        {
            var uniqueList = new UniqueList<string>(3);

            uniqueList.Capacity.Should().Be(3);
        }

        [Test]
        public void CopyItems_Of_Enumerable_From_Constructor()
        {
            var uniqueList = new UniqueList<string>(new [] {"I", "am", "here"});

            uniqueList.Should().Equal("I", "am", "here");
        }

        [Test]
        public void Throw_ItemAlreadyExistException_When_Enumerable_From_Constructor_Have_Duplicates()
        {
            Action constructUniqueListWithDuplicates = () =>
                new UniqueList<string>(new[] {"This", "Enumerable", "has", "duplicates", "duplicates"});

            constructUniqueListWithDuplicates.Should().Throw<ItemAlreadyExistException>()
                .WithMessage("Attempted to add an item that is already in the UniqueList.");
        }

        [Test]
        public void AddItem_If_Does_Not_Contain_It()
        {
            var uniqueList = new UniqueList<int>();
            
            uniqueList.Add(42);
            uniqueList.Add(54);

            uniqueList.Should().Equal(42, 54);
        }

        [Test]
        public void Throw_ItemAlreadyExistException_If_Contains_It()
        {
            var uniqueList = new UniqueList<int> {42};

            uniqueList.Invoking(list => list.Add(42))
                .Should()
                .Throw<ItemAlreadyExistException>(
                    "Attempted to add an item that is already in the UniqueList.");
        }

        [Test]
        public void Add_Enumerable_Without_Duplicates()
        {
            var uniqueList = new UniqueList<string>();
            
            uniqueList.AddRange(new []{"I", "am", "here"});
            uniqueList.AddRange(new [] {"and", "me", "too"});

            uniqueList.Should().Equal("I", "am", "here", "and", "me", "too");
        }

        [Test]
        public void Throw_ItemAlreadyExistException_When_Try_To_Add_Enumerable_With_Duplicates()
        {
            var uniqueList = new UniqueList<string>();

            uniqueList.Invoking(list => list.AddRange(new[] {"This", "Enumerable", "has", "duplicates", "duplicates"}))
                .Should().Throw<ItemAlreadyExistException>(
                    "Attempted to add an item that is already in the UniqueList.");
        }

        [Test]
        public void Insert_Item_If_Does_Not_Contain_It()
        {
            var uniqueList = new UniqueList<string> {"I", "here"};
            
            uniqueList.Insert(1, "am");

            uniqueList.Should().Equal("I", "am", "here");
        }

        [Test]
        public void Throw_ItemAlreadyExistException_When_Try_To_Insert_An_Item_Which_Already_Is_In_List()
        {
            var uniqueList = new UniqueList<int>{42, 54};

            uniqueList.Invoking(list => list.Insert(1, 42))
                .Should().Throw<ItemAlreadyExistException>(
                    "Attempted to add an item that is already in the UniqueList.");
        }

        [Test]
        public void Insert_Enumerable_Without_Duplicates()
        {
            var uniqueList = new UniqueList<string>{"Here", "Should", "Be Enumerable"};
            
            uniqueList.InsertRange(1, new []{"I", "am", "here"});

            uniqueList.Should().Equal("Here", "I", "am", "here", "Should", "Be Enumerable");
        }

        [TestCase("This","message", "already in list")]
        [TestCase("Something new", "but", "With", "duplicates", "duplicates")]
        [Test]
        public void Throw_ItemAlreadyExistException_When_Insert_Enumerable_With_Duplicates(params string[] input)
        {
            var uniqueList = new UniqueList<string> {"I have a", "message"};

            uniqueList.Invoking(list => list.InsertRange(1, input))
                .Should().Throw<ItemAlreadyExistException>()
                .WithMessage("Attempted to add an item that is already in the UniqueList.");
        }

        [Test]
        public void Remove_Item_Which_Is_In_The_UniqueList()
        {
            var uniqueList = new UniqueList<int>{42, 54};
            
            uniqueList.Remove(42);

            uniqueList.Should().Equal(54);
        }

        [Test]
        public void Throw_ItemDoesNotExistException_When_Remove_Item_Which_Is_Not_In_The_UniqueList()
        {
            var uniqueList = new UniqueList<string>{"I", "am", "here"};

            uniqueList.Invoking(list => list.Remove("not"))
                .Should().Throw<ItemDoesNotExistException>()
                .WithMessage("Attempted to remove an item that is not in the UniqueList.");
        }
    }
}