using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue<string>();
            queue.Enqueue("lol", 9);
            queue.Enqueue("kek", 10);
            queue.Enqueue("qwe", 10);
            
            Console.WriteLine(queue.Dequeue());
        }
    }
}