using System;

namespace test2
{
    class Program
    {
        static void Main()
        {
            var queue = new Queue();
            queue.Enqueue(1, 1);
            queue.Enqueue(9, 9);
            queue.Enqueue(2, 2);
            queue.Enqueue(5, 5);
            queue.Enqueue(3, 3);
            queue.Enqueue(4, 4);
            queue.Enqueue(5, 10);
            queue.Enqueue(7, 10);
            queue.Enqueue(10, 10);
            queue.Enqueue(7, 7);
            queue.Enqueue(8, 8);
            queue.Enqueue(6, 6);
            var result = queue.Dequeue();
            Console.WriteLine(result);
            result = queue.Dequeue();
            Console.WriteLine(result);
            result = queue.Dequeue();
            Console.WriteLine(result);
            result = queue.Dequeue();
            Console.WriteLine(result);
        }
    }
}
