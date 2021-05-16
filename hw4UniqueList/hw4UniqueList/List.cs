using System;
using System.Collections.Generic;
using System.Text;

namespace hw4UniqueList
{
    /// <summary>
    /// Список
    /// </summary>
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

        /// <summary>
        /// Возвращает размер списка
        /// </summary>
        public int GetSize()
            => Size;

        /// <summary>
        /// Проверка на пустоту списка
        /// </summary>
        /// <returns>возвращает true, если список пуст</returns>
        public bool IsEmpty()
            => head == null;

        private void CheckSize(int index)
        {
            if (index > Size || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Функция вставки
        /// </summary>
        /// <param name="position">позиция узла</param>
        /// <param name="value">значение в узле</param>
        public virtual void Insert(int position, int value)
        {
            CheckSize(position);
            if (IsEmpty() && position == 0)
            {
                head = new Node(value, null);
                Size++;
                return;
            }
            else if (IsEmpty() && position != 0)
            {
                throw new IndexOutOfRangeException();
            }
            var runner = head;
            if (position == 0)
            {
                var node = new Node(value, head);
                head = node;
                Size++;
                return;
            }
            int index = 1;
            while (index < position)
            {
                if (runner.Next != null)
                {
                    runner = runner.Next;
                    index++;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            var newNode = new Node(value, runner.Next);
            runner.Next = newNode;
            Size++;
        }

        /// <summary>
        /// Функция удаления по индексу
        /// </summary>
        /// <param name="position">индекс узла</param>
        /// <returns>возвращает значение в узле</returns>
        public virtual int DeleteByIndex(int position)
        {
            CheckSize(position);
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }
            if (position == 1)
            {
                var node = head.Next;
                var result = head.Value;
                head = node;
                Size--;
                return result;
            }
            var runner = head;
            int index = 1;
            while (index < position - 1)
            {
                if (runner.Next != null)
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
        /// Функция удаление по значению
        /// </summary>
        /// <param name="value">значение, которое надо удалить</param>
        public virtual void DeleteByValue(int value)
        {
            if (head.Value == value)
            {
                head = head.Next;
                Size--;
                return;
            }
            var runner  = head;
            while (runner.Next != null)
            {
                if (runner.Next.Value == value)
                {
                    runner.Next = runner.Next.Next;
                    Size--;
                    return;
                }
                runner = runner.Next;
            }
            throw new ValueDoesNotExistException();
        }

        private Node GoToPosition(int position, Node node)
        {
            int index = 1;
            while (index < position)
            {
                node = node.Next;
                index++;
            }
            return node;
        }

        /// <summary>
        /// Смена значения в узле по индексу
        /// </summary>
        /// <param name="position">индекс узла</param>
        /// <param name="value">новое значение</param>
        public virtual void ChangeByIndex(int position, int value)
        {
            CheckSize(position);
            var runner  = GoToPosition(position, head);
            runner.Value = value;
        }

        /// <summary>
        /// получить значение узла по его индексу
        /// </summary>
        /// <param name="position">индекс узла</param>
        /// <returns>возвращает значение в узле</returns>
        public int GetValueByIndex(int position)
        {
            CheckSize(position);
            var runner = GoToPosition(position, head);
            return runner.Value;
        }

        /// <summary>
        /// проверка, есть ли такое значение в списке
        /// </summary>
        /// <param name="value">значение, которое хотим проверить</param>
        /// <returns>возвращает true, если нашелся узел с таким значением</returns>
        public bool Contains(int value)
        {
            var runner  = head;
            while (runner != null)
            {
                if (runner.Value == value)
                {
                    return true;
                }
                runner = runner.Next;
            }
            return false;
        }
    }
}
