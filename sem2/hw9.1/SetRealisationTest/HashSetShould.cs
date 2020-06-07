using System;
using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;
using SetRealisation;

namespace SetRealisationTest
{
    public class Tests
    {
        private class Box
        {
            public int Height { get; }
            public int Width { get; }
            public int Length { get; }

            public Box(int length, int width, int height)
            {
                Length = length;
                Width = width;
                Height = height;
            }
        }
        
        private class BoxSameDimensionsComparer : EqualityComparer<Box>
        {
            public override bool Equals(Box box1, Box box2)
            {
                if (box1 == null && box2 == null)
                    return true;
                if (box1 == null || box2 == null)
                    return false;

                return box1.Height == box2.Height &&
                       box1.Length == box2.Length &&
                       box1.Width == box2.Width;
            }

            public override int GetHashCode(Box box)
            {
                var hashCode = box.Height ^ box.Length ^ box.Width;
                return hashCode.GetHashCode();
            }
        }
        
        private class BoxSameVolumeComparer : EqualityComparer<Box>
        {
            public override bool Equals(Box box1, Box box2)
            {
                if (box1 == null && box2 == null)
                    return true;
                if (box1 == null || box2 == null)
                    return false;

                return box1.Height * box1.Width * box1.Length ==
                       box2.Height * box2.Width * box2.Length;
            }

            public override int GetHashCode(Box box)
            {
                var hashCode = box.Height * box.Length * box.Width;
                return hashCode.GetHashCode();
            }
        }

        private readonly Box[] boxes = {new Box(3, 2, 2), new Box(1, 4, 3), new Box(2, 2, 8)};
        private MyHashSet<Box> hashSet;
        
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
                    words.Add(EqualityComparer<string>.Default.GetHashCode(tempString), tempString);
                }
                catch (Exception)
                {
                    break;
                }
            }

            var collisionHash = EqualityComparer<string>.Default.GetHashCode(tempString);

            return (words[collisionHash], tempString);
        }
        
        [Test]
        public void Should_Implement_ISet()
        {
            typeof(ISet<Box>).IsAssignableFrom(typeof(HashSet<Box>)).Should().BeTrue();
        }

        [Test]
        public void Should_BeEmptyAfterCreation_WithoutComparer()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Should().BeEmpty();
            hashSet.Count.Should().Be(0);
            hashSet.Comparer.Should().Be(EqualityComparer<Box>.Default);
        }

        [Test]
        public void Should_BeEmpty_AfterCreation_WithComparer()
        {
            var boxComparer = new BoxSameDimensionsComparer();
            hashSet = new MyHashSet<Box>(boxComparer);

            hashSet.Should().BeEmpty();
            hashSet.Count.Should().Be(0);
            hashSet.Comparer.Should().Be(boxComparer);
        }

        [Test]
        public void ShouldAddItem_As_Collection()
        {
            hashSet = new MyHashSet<Box>();
            var hashSetAsCollection = (ICollection<Box>) hashSet;
            
            hashSetAsCollection.Add(boxes[0]);

            hashSetAsCollection.Should().BeEquivalentTo(boxes[0]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void ShouldAddItem()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Add(boxes[0]).Should().BeTrue();
            hashSet.Should().BeEquivalentTo(boxes[0]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void ShouldRemoveItem()
        {
            hashSet = new MyHashSet<Box> {boxes[0], boxes[1]};

            hashSet.Remove(boxes[1]).Should().BeTrue();
            hashSet.Should().BeEquivalentTo(boxes[0]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void ThrowArgumentNullException_When_TryToAddNull()
        {
            hashSet = new MyHashSet<Box>();
            
            hashSet.Invoking(x => x.Add(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void RemoveNull()
        {
            hashSet = new MyHashSet<Box>();
            var hashSetAsCollection = (ICollection<Box>) hashSet;
            hashSetAsCollection.Add(null!);
            hashSet = (MyHashSet<Box>)hashSetAsCollection;

            hashSet.Remove(null!).Should().BeTrue();
            hashSet.Should().BeEmpty();
            hashSet.Count.Should().Be(0);
        }

        [Test]
        public void RemoveWithUsingComparer()
        {
            var boxComparer = new BoxSameVolumeComparer();
            hashSet = new MyHashSet<Box>(boxComparer) {boxes[0], boxes[2]};
            
            hashSet.Remove(boxes[1]).Should().BeTrue();
            hashSet.Should().BeEquivalentTo(boxes[2]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void ReturnFalse_After_TryToRemoveItem_ThatItDoesNotContain()
        {
            hashSet = new MyHashSet<Box>{boxes[0]};

            hashSet.Remove(boxes[2]).Should().BeFalse();
            hashSet.Should().BeEquivalentTo(boxes[0]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void ReturnFalse_After_TryToAddItem_ThatItAlreadyContain()
        {
            hashSet = new MyHashSet<Box> {boxes[0]};

            hashSet.Add(boxes[0]).Should().BeFalse();
            hashSet.Should().BeEquivalentTo(boxes[0]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void AddItem_WithUsingComparer()
        {
            var boxComparer = new BoxSameVolumeComparer();
            hashSet = new MyHashSet<Box>(boxComparer) {boxes[0], boxes[2]};
            
            hashSet.Add(boxes[1]).Should().BeFalse();
            hashSet.Should().BeEquivalentTo(boxes[0], boxes[2]);
            hashSet.Count.Should().Be(2);
        }

        [Test]
        public void ReturnFalse_After_Checking_For_The_Presence_Of_An_Item_ThatItDoesNotContain()
        {
            hashSet = new MyHashSet<Box> {boxes[0], boxes[1]};

            hashSet.Contains(boxes[2]).Should().BeFalse();
            hashSet.Should().BeEquivalentTo(boxes[0], boxes[1]);
            hashSet.Count.Should().Be(2);
        }

        [Test]
        public void ReturnTrue_After_Checking_For_The_Presence_Of_An_Item_ThatItContains()
        {
            hashSet = new MyHashSet<Box> {boxes[0]};

            hashSet.Contains(boxes[0]).Should().BeTrue();
            hashSet.Should().BeEquivalentTo(boxes[0]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void Check_For_The_Presence_Of_An_Item_With_Using_Comparer()
        {
            hashSet = new MyHashSet<Box>(new BoxSameVolumeComparer()){boxes[0]};

            hashSet.Contains(boxes[1]).Should().BeTrue();
            hashSet.Should().BeEquivalentTo(boxes[0]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void Check_For_The_Presence_Of_Null()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Contains(null).Should().BeFalse();
            hashSet.Should().BeEmpty();
            hashSet.Count.Should().Be(0);
        }

        [Test]
        public void Clear()
        {
            hashSet = new MyHashSet<Box>(boxes);
            
            hashSet.Clear();

            hashSet.Should().BeEmpty();
            hashSet.Count.Should().Be(0);
        }

        [Test]
        public void Throw_ArgumentNullException_After_CopyTo_Null()
        {
            hashSet = new MyHashSet<Box>();
            
            hashSet.Invoking(x => x.CopyTo(null!, 1)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Throw_ArgumentException_After_CopyTo_When_Not_Enough_Space_In_Destination_Array()
        {
            hashSet = new MyHashSet<Box>(boxes);
            var array = new Box[hashSet.Count - 1];

            hashSet.Invoking(x => x.CopyTo(array, 0)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void Throw_ArgumentOutOfRangeException_After_CopyTo_With_Negative_ArrayIndex()
        {
            hashSet = new MyHashSet<Box>();
            var array = new Box[2];

            hashSet.Invoking(x => x.CopyTo(array, -1)).Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void CopyTo()
        {
            hashSet = new MyHashSet<Box>(boxes);
            var array = new Box[hashSet.Count];

            hashSet.CopyTo(array, 0);

            array.Should().BeEquivalentTo(boxes);
        }

        [Test]
        public void Throw_ArgumentNullException_WhenExceptWith_Null()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Invoking(x => x.ExceptWith(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ExceptWith()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            
            hashSet.ExceptWith(new []{boxes[0], boxes[1]});

            hashSet.Should().BeEquivalentTo(boxes[2]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void Throw_ArgumentNullException_WhenIntersectWith_Null()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Invoking(x => x.IntersectWith(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void IntersectWith()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            
            hashSet.IntersectWith(new []{boxes[1]});

            hashSet.Should().BeEquivalentTo(boxes[1]);
            hashSet.Count.Should().Be(1);
        }

        [Test]
        public void Throw_ArgumentNullException_When_Executing_IsProperSubsetOf_With_NullArgument()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Invoking(x => x.IsProperSubsetOf(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ReturnFalse_On_IsProperSubset_When_CollectionsAreEqual()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());

            hashSet.IsProperSubsetOf(boxes).Should().BeFalse();
        }

        [Test]
        public void ReturnTrue_When_ItIsProperSubset()
        {
            hashSet = new MyHashSet<Box>(new []{boxes[0], boxes[1]}, new BoxSameDimensionsComparer());

            hashSet.IsProperSubsetOf(boxes).Should().BeTrue();
        }

        [Test]
        public void ReturnFalse_When_ItIsNotProperSubset()
        {
            hashSet = new MyHashSet<Box>(boxes);

            hashSet.IsProperSubsetOf(new[] {boxes[0]}).Should().BeFalse();
        }

        [Test]
        public void Throw_ArgumentNullException_When_Executing_IsProperSupersetOf_With_NullArgument()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Invoking(x => x.IsProperSupersetOf(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ReturnFalse_On_IsProperSuperset_When_CollectionsAreEqual()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());

            hashSet.IsProperSupersetOf(boxes).Should().BeFalse();
        }

        [Test]
        public void ReturnTrue_When_ItIsProperSuperset()
        {
            hashSet = new MyHashSet<Box>(boxes);

            hashSet.IsProperSupersetOf(new[] {boxes[0]}).Should().BeTrue();
        }

        [Test]
        public void ReturnFalse_When_ItIsNotProperSuperset()
        {
            hashSet = new MyHashSet<Box>(new []{boxes[0], boxes[1]}, new BoxSameDimensionsComparer());

            hashSet.IsProperSupersetOf(boxes).Should().BeFalse();
        }
        
        [Test]
        public void Throw_ArgumentNullException_When_Executing_IsSubsetOf_With_NullArgument()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Invoking(x => x.IsSubsetOf(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ReturnTrue_On_IsSubset_When_CollectionsAreEqual()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());

            hashSet.IsSubsetOf(boxes).Should().BeTrue();
        }

        [Test]
        public void ReturnTrue_When_ItIsSubset()
        {
            hashSet = new MyHashSet<Box>(new []{boxes[0], boxes[1]}, new BoxSameDimensionsComparer());

            hashSet.IsSubsetOf(boxes).Should().BeTrue();
        }

        [Test]
        public void ReturnFalse_When_ItIsNotSubset()
        {
            hashSet = new MyHashSet<Box>(boxes);

            hashSet.IsSubsetOf(new[] {boxes[0]}).Should().BeFalse();
        }
        
        [Test]
        public void Throw_ArgumentNullException_When_Executing_IsSupersetOf_With_NullArgument()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Invoking(x => x.IsSupersetOf(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ReturnTrue_On_IsSuperset_When_CollectionsAreEqual()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());

            hashSet.IsSupersetOf(boxes).Should().BeTrue();
        }

        [Test]
        public void ReturnTrue_When_ItIsSuperset()
        {
            hashSet = new MyHashSet<Box>(boxes);

            hashSet.IsSupersetOf(new[] {boxes[0]}).Should().BeTrue();
        }

        [Test]
        public void ReturnFalse_When_ItIsNotSuperset()
        {
            hashSet = new MyHashSet<Box>(new []{boxes[0], boxes[1]}, new BoxSameDimensionsComparer());

            hashSet.IsSupersetOf(boxes).Should().BeFalse();
        }

        [Test]
        public void Throw_ArgumentNullException_When_Executing_Overlaps_WithNull()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Invoking(x => x.Overlaps(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ReturnFalse_When_Overlaps_With_EmptyCollection()
        {
            hashSet = new MyHashSet<Box>(boxes);

            hashSet.Overlaps(new Box[0]).Should().BeFalse();
        }
        
        [Test]
        public void ReturnTrue_When_Overlaps_TwoCollections_With_SameElements()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameVolumeComparer());

            hashSet.Overlaps(new[] {boxes[0]}).Should().BeTrue();
        }

        [Test]
        public void ReturnFalse_When_Overlaps_TwoCollections_Without_SameElements()
        {
            hashSet = new MyHashSet<Box>(new[]{boxes[0]}, new BoxSameDimensionsComparer());

            hashSet.Overlaps(new[] {boxes[2]}).Should().BeFalse();
        }
        
        [Test]
        public void Throw_ArgumentNullException_When_Executing_SetEquals_With_NullArgument()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Invoking(x => x.SetEquals(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void ReturnTrue_On_SetEquals_When_CollectionsAreEmpty()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.SetEquals(new Box[0]).Should().BeTrue();
        }

        [Test]
        public void ReturnTrue_On_SetEquals_When_CollectionsAreEqual()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());

            hashSet.SetEquals(boxes).Should().BeTrue();
        }

        [Test]
        public void ReturnFalse_On_SetEquals_When_CollectionsAreNotEmpty()
        {
            hashSet = new MyHashSet<Box>(new []{boxes[0], boxes[1]}, new BoxSameDimensionsComparer());

            hashSet.SetEquals(boxes).Should().BeFalse();
        }

        [Test]
        public void Throw_ArgumentNullException_When_Executing_SymmetricExceptWith_With_NullArgument()
        {
            hashSet = new MyHashSet<Box>();
            
            hashSet.Invoking(x => x.SymmetricExceptWith(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void NotChange_After_SymmetricExceptWith_EmptyCollection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            
            hashSet.SymmetricExceptWith(new Box[0]);

            hashSet.Should().BeEquivalentTo(boxes);
            hashSet.Count.Should().Be(3);
        }

        [Test]
        public void AddAllCollection_After_SymmetricExceptWith_If_It_IsEmpty()
        {
            hashSet = new MyHashSet<Box>();
            
            hashSet.SymmetricExceptWith(boxes);

            hashSet.Should().BeEquivalentTo(boxes);
            hashSet.Count.Should().Be(3);
        }

        [Test]
        public void SymmetricExceptWithCorrectly()
        {
            hashSet = new MyHashSet<Box>(new[]{boxes[0], boxes[2]});

            hashSet.SymmetricExceptWith(new[] {boxes[1], boxes[2]});
            
            hashSet.Should().BeEquivalentTo(boxes[0], boxes[1]);
            hashSet.Count.Should().Be(2);
        }

        [Test]
        public void Throw_ArgumentNullException_When_Executing_UnionWith_With_NullArgument()
        {
            hashSet = new MyHashSet<Box>();

            hashSet.Invoking(x => x.UnionWith(null!)).Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void UnionWith_TwoCollections_WithSameItems()
        {
            hashSet = new MyHashSet<Box>(new []{boxes[0], boxes[1]}, new BoxSameDimensionsComparer());
            
            hashSet.UnionWith(new []{boxes[1], boxes[2]});

            hashSet.Should().BeEquivalentTo(boxes);
            hashSet.Count.Should().Be(3);
        }
        
        [Test]
        public void AddItem_After_Removing_It()
        {
            var hashSetWithStrings = new HashSet<string> {"42"};

            hashSetWithStrings.Remove("42");
            hashSetWithStrings.Add("42");

            hashSetWithStrings.Should().BeEquivalentTo("42");
        }
        
        [Test]
        public void AddTwoDifferentStrings_With_TheSameHashCode()
        {
            var hashSetForString = new HashSet<string>();
            var (firstString, secondString) = GenerateTwoDifferentStringsWithTheSameHashCode();
            
            hashSetForString.Add(firstString);
            hashSetForString.Add(secondString);

            hashSetForString.Should().BeEquivalentTo(firstString, secondString);
        }
        
        [Test]
        public void NotRemoveString_With_SameHashCode()
        {
            var hashSetForString = new HashSet<string>();
            var (firstString, secondString) = GenerateTwoDifferentStringsWithTheSameHashCode();
            hashSetForString.Add(firstString);
            
            hashSetForString.Remove(secondString);

            hashSetForString.Should().BeEquivalentTo(firstString);
        }
        
        [Test]
        public void ReturnFalse_When_It_Checks_For_The_Presence_Of_An_String_With_SameHashCode()
        {
            var hashSetForStrings = new HashSet<string>();
            var (firstString, secondString) = GenerateTwoDifferentStringsWithTheSameHashCode();
            hashSetForStrings.Add(firstString);

            hashSetForStrings.Contains(secondString).Should().BeFalse();
        }

        [Test]
        public void Throw_ArgumentNullException_When_Creating_With_Collection_Which_Is_Null()
        {
            Action action = () => new MyHashSet<Box>(null, new BoxSameDimensionsComparer());

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Should_Correctly_ExceptWith_ReferenceEqual_Collection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameVolumeComparer());
            var secondHashSet = hashSet;

            hashSet.ExceptWith(secondHashSet);

            hashSet.Should().BeEmpty();
        }

        [Test]
        public void Should_Correctly_IntersectWith_ReferenceEqual_Collection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            var secondHashSet = hashSet;
            
            hashSet.IntersectWith(secondHashSet);

            hashSet.Should().BeEquivalentTo(boxes);
        }

        [Test]
        public void Should_ReturnFalse_After_Executing_IsProperSubsetOf_ReferenceEqual_Collection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            var secondHashSet = hashSet;

            hashSet.IsProperSubsetOf(secondHashSet).Should().BeFalse();
        }

        [Test]
        public void Should_ReturnFalse_After_Executing_IsProperSupersetOf_ReferenceEqual_Collection()
        {
            hashSet=new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            var secondHashSet = hashSet;

            hashSet.IsProperSupersetOf(secondHashSet).Should().BeFalse();
        }

        [Test]
        public void Should_ReturnTrue_After_Executing_IsSubsetOf_ReferenceEqual_Collection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            var secondHashSet = hashSet;

            hashSet.IsSubsetOf(secondHashSet).Should().BeTrue();
        }

        [Test]
        public void Should_ReturnTrue_After_Executing_IsSupersetOf_ReferenceEqual_Collection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            var secondHashSet = hashSet;

            hashSet.IsSupersetOf(secondHashSet).Should().BeTrue();
        }

        [Test]
        public void Should_ReturnTrue_After_Overlaps_With_ReferenceEqual_Collection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            var secondHashSet = hashSet;

            hashSet.Overlaps(secondHashSet).Should().BeTrue();
        }

        [Test]
        public void Should_ReturnTrue_After_SetEquals_With_ReferenceEqual_Collection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            var secondHashSet = hashSet;

            hashSet.SetEquals(secondHashSet).Should().BeTrue();
        }

        public void Should_Correctly_SymmetricExceptWith_ReferenceEqual_Collection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            var secondHashSet = hashSet;
            
            hashSet.SymmetricExceptWith(secondHashSet);

            hashSet.Should().BeEmpty();
        }

        public void Should_Correctly_UnionWith_ReferenceEqual_Collection()
        {
            hashSet = new MyHashSet<Box>(boxes, new BoxSameDimensionsComparer());
            var secondHashSet = hashSet;
            
            hashSet.UnionWith(secondHashSet);

            hashSet.Should().BeEquivalentTo(boxes);
        }
    }
}