using NUnit.Framework;
using UniqueListRealisation;
using FluentAssertions;

namespace UniqueListTest
{
    public class UniqueListShould
    {
        [Test]
        public void AddItem_If_Does_Not_Contain_It()
        {
            var uniqueList = new UniqueList<int>();
            
            uniqueList.AddElementByIndex(42, 0);
            uniqueList.AddElementByIndex(54, 1);

            uniqueList.Should().Equal(42, 54);
        }

        [Test]
        public void Throw_ItemAlreadyExistException_If_Contains_It()
        {
            var uniqueList = new UniqueList<int>();
            uniqueList.AddElementByIndex(42, 0);

            uniqueList.Invoking(list => list.AddElementByIndex(42, 0))
                .Should()
                .Throw<ItemAlreadyExistException>(
                    "Attempted to add an item that is already in the UniqueList.");
        }
        
        [Test]
        public void Remove_Item_Which_Is_In_The_UniqueList()
        {
            var uniqueList = new UniqueList<int>();
            uniqueList.AddElementByIndex(42, 0);
            uniqueList.AddElementByIndex(54, 0);
            
            uniqueList.Remove(42);

            uniqueList.Should().Equal(54);
        }

        [Test]
        public void Throw_ItemDoesNotExistException_When_Remove_Item_Which_Is_Not_In_The_UniqueList()
        {
            var uniqueList = new UniqueList<string>();

            uniqueList.AddElementByIndex("I", 0);
            uniqueList.AddElementByIndex("am", 1);
            uniqueList.AddElementByIndex("here", 2);
            
            uniqueList.Invoking(list => list.Remove("not"))
                .Should().Throw<ItemDoesNotExistException>()
                .WithMessage("Attempted to remove an item that is not in the UniqueList.");
        }
    }
}