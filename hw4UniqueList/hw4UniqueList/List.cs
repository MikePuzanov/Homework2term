using System;
using System.Collections.Generic;
using System.Text;

namespace hw4UniqueList
{
    public class List
    {
        private int Size { get; set; }
        private class Node
        {
            public int Value { get; set; }

            public Node Next { get; set; }
            
            public Node(int value, Node node)
            {
                Value = value;
                Next = node;
            }
        }

        private Node head;

        private Node runner;

        private Node GetNext(Node node)
            => node.Next;

        private bool IsEmpty()
            => head == null;

        public List()
        {
            Size = 0;
            head = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="possition"></param>
        /// <param name="value"></param>
        public void Insert(int possition, int value)
        {
            if (possition > Size)
            {
                throw new Exception();
            }
            if (IsEmpty() && possition == 0)
            {
                head = new Node(value, null);
            }
            else if (IsEmpty() && possition != 0)
            {
                throw new Exception();
            }
            runner = head;
            if (possition == 0)
            {
                var node = new Node(value, head);
                head = node;
                return;
            }
            int index = 1;
            while (index < possition)
            {
                if (GetNext(runner) != null)
                {
                    runner = runner.Next;
                    index++;
                }
                else
                {
                    throw new Exception();
                }
            }
            var NewNode = new Node(value, runner.Next);
            runner.Next = NewNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="possition"></param>
        /// <returns></returns>
        public int Delete(int possition)
        {
            if (possition > Size)
            {
                throw new Exception();
            }
            if (IsEmpty())
            {
                throw new Exception();
            }
            if (possition == 1)
            {
                var node = head.Next;
                var result = head.Value;
                head = node;
                return result;
            }
            int index = 1;
            while (index < possition - 1)
            {
                if (GetNext(runner) != null)
                {
                    runner = runner.Next;
                    index++;
                }
                else
                {
                    throw new Exception();
                }
            }
            var returnResult = runner.Next.Value;
            runner.Next = runner.Next.Next;
            return returnResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="possition"></param>
        /// <param name="value"></param>
        public void ChangeByIndex(int possition, int value)
        {

        }

    }
}
