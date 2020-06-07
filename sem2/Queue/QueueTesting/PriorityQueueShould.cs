using NUnit.Framework;
using Queue;
using FluentAssertions;

namespace QueueTesting
{
    public class Tests
    {
        private PriorityQueue<string> _priorityQueue;
        [SetUp]
        public void Setup()
        {
            _priorityQueue = new PriorityQueue<string>();
        }

        [Test]
        public void Throw_QueueIsEmptyException_ThenTryToDequeueEmptyQueue()
        {
            _priorityQueue.Invoking(x => x.Dequeue()).Should().Throw<QueueIsEmptyException>();
        }

        [Test]
        public void ShouldDequeueItemWithHigherPriority()
        {
            _priorityQueue.Enqueue("lol", 1);
            _priorityQueue.Enqueue("kek", 10);

            _priorityQueue.Dequeue().Should().Be("kek");
        }

        [Test]
        public void ShouldDequeueSameItemAfterEnqueue()
        {
            _priorityQueue.Enqueue("123", 1);

            _priorityQueue.Dequeue().Should().Be("123");
        }
    }
}