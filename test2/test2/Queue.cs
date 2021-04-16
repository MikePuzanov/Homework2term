using System;

namespace test2
{
    /// <summary>
    /// queue with priority
    /// </summary>
    public class Queue
    {
        /// <summary>
        /// node on queue
        /// </summary>
        private class Node
        {
            public int Priority { get; set; }

            public int Value { get; set; }

            public Node Next { get; set; }
            public Node(int priority, int value)
            {
                Value = value;
                Priority = priority;
                Next = null;
            }
        }

        private Node head;

        private Node tail;

        public Queue()
            => head = null;


        /// <summary>
        /// add to queue
        /// </summary>
        public void Enqueue(int value, int priority)
        {
            if (head == null)
            {
                head = new Node(priority, value);
                head.Next = null;
                tail = head;
                return;
            }
            var node = tail;
            var newNode = new Node(priority, value);
            tail = newNode;
            node.Next = tail;
        }

        private Node runner;

        private int GetMaxPriority()
        {
            int priority = int.MinValue;
            runner = head;
            while (runner != null)
            {
                if (runner.Priority > priority)
                {
                    priority = runner.Priority;
                    runner = runner.Next;
                    continue;
                }
                runner = runner.Next;
            }
            return priority;
        }

        /// <summary>
        /// function remove from queue
        /// </summary>
        /// <returns>value's array with max priority</returns>
        public int Dequeue()
        {
            if (Empty())
            {
                throw new QueueException("Queue is Empty!");
            }
            int maxPriority = GetMaxPriority();
            runner = head;
            int result = 0;
            Node previosNode = null;
            while (runner.Next != null)
            {
                if (runner.Next.Priority == maxPriority)
                {
                    result = runner.Next.Value;;
                    runner.Next = runner.Next.Next;
                    previosNode = runner;
                    break;
                }
                runner = runner.Next;
            }
            if (runner.Priority == maxPriority && runner.Next == null)
            {
                result = runner.Next.Value;
                runner = null;
                tail = previosNode;
            }
            return result;
        }

        /// <summary>
        /// is queue empty?
        /// </summary>
        /// <returns>true - queue is empty</returns>
        public bool Empty()
            => head == null;

    }
}