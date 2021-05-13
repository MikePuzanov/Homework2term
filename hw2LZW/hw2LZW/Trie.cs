using System;
using System.Collections.Generic;

namespace Hw2LZW
{
    /// <summary>
    /// вспомогательный класс для реализация Lzw
    /// </summary>
    public class Trie
    {
        private class Node
        {
            public byte Bytes { get; }

            public bool IsUsed { get; set; }

            public int IdByte;

            public int CodeBytes { get; set; }

            public Dictionary<byte, Node> Sons;

            public Node(byte bytes, int codeByte, bool isUsed)
            {
                IsUsed = isUsed;
                Bytes = bytes;
                IdByte = codeByte;
                Sons = new Dictionary<byte, Node>();
            }

            public Node IsFind(byte value)
                => Sons.TryGetValue(value, out Node node) ? node : null;
        }

        private Node root = new Node(0, 0, false);

        private Node runner;

        public Trie()
        {
            for (int i = 0; i < 256; ++i)
            {
                InitRoot((byte)i, i);
            }
            runner = root;
        }

        public int CountCodes { get; set; }

        private void InitRoot(byte idSymbol, int index)
        {

            var son = new Node(idSymbol, index, false);
            root.Sons.Add(idSymbol, son);
            son.CodeBytes = CountCodes;
            CountCodes++;
        }

        private bool CheckAdd(byte value, Node node)
            => node.IsFind(value) == null;

        public int LastCode { get; set; }

        /// <summary>
        /// функция добавления
        /// </summary>
        /// <param name="value">байт, который хотим добавить</param>
        /// <returns>если такой байт уже есть, то вернем "-1"</returns>
        public int IsAdd(byte value)
        {
            if (runner == root)
            {
                var check = runner.Sons[value];
                if (!check.IsUsed)
                {
                    check.IsUsed = true;
                    runner = runner.Sons[value];
                    LastCode = runner.Bytes;
                    return -1;
                }
            }
            var isCheck = CheckAdd(value, runner);
            if (isCheck)
            {
                var son = new Node(value, CountCodes, true);
                son.CodeBytes = CountCodes;
                CountCodes++;
                runner.Sons.Add(value, son);
                runner = root;
                return LastCode;
            }
            else
            {
                runner = runner.Sons[value];
                LastCode = runner.CodeBytes;
                return -1;
            }    
        }

        /// <summary>
        /// функция для возврата кода у узла
        /// </summary>
        /// <returns>возвращается код узла</returns>
        public int GetCode()
            => runner.Bytes;
    }
}