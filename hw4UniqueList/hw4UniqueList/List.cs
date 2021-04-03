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

        public int GetSize()
            => Size;

        private Node GetNext(Node node)
            => node.Next;

        private bool IsEmpty()
            => head == null;

        private void CheckSize(int index)
        {
            if (index > Size || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

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
        public virtual void Insert(int possition, int value)
        {
            CheckSize(possition);
            if (IsEmpty() && possition == 0)
            {
                head = new Node(value, null);
                Size++;
                return;
            }
            else if (IsEmpty() && possition != 0)
            {
                throw new IndexOutOfRangeException();
            }
            runner = head;
            if (possition == 0)
            {
                var node = new Node(value, head);
                head = node;
                Size++;
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
                    throw new IndexOutOfRangeException();
                }
            }
            var NewNode = new Node(value, runner.Next);
            runner.Next = NewNode;
            Size++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="possition"></param>
        /// <returns></returns>
        public virtual int DeleteByIndex(int possition)
        {
            CheckSize(possition);
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }
            if (possition == 1)
            {
                var node = head.Next;
                var result = head.Value;
                head = node;
                Size--;
                return result;
            }
            runner = head;
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
                    throw new IndexOutOfRangeException();
                }
            }
            var returnResult = runner.Next.Value;
            runner.Next = runner.Next.Next;
            Size--;
            return returnResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public virtual void DeleteByValue(int value)
        {
            if (head.Value == value)
            {
                head = head.Next;
                Size--;
                return;
            }
            runner = head;
            while (GetNext(runner) != null)
            {
                if (GetNext(runner).Value == value)
                {
                    runner.Next = GetNext(runner).Next;
                    Size--;
                    return;
                }
                runner = GetNext(runner);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="possition"></param>
        /// <param name="value"></param>
        public virtual void ChangeByIndex(int possition, int value)
        {
            CheckSize(possition);
            int index = 1;
            runner = head;
            while (index < possition && GetNext(runner) != null)
            {
                runner = GetNext(runner);
                index++;
            }
            runner.Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="possition"></param>
        /// <returns></returns>
        public int GetValueByIndex(int possition)
        {
            CheckSize(possition);
            int index = 1;
            runner = head;
            while (index < possition && GetNext(runner) != null)
            {
                runner = GetNext(runner);
                index++;
            }
            return runner.Value;
        }

        public bool IsConsist(int value)
        {
            runner = head;
            while (runner != null)
            {
                if (runner.Value == value)
                {
                    return true;
                }
                runner = GetNext(runner);
            }
            return false;
        }
    }
}
