using System;
using System.Collections.Generic;
using System.Text;

namespace hw2LZW
{
    public class Trie
    {
        private class Node
        {
            public byte IdSymbol { get; set; }

            public int IndexSymbol { get; set; }

            public int CodeBytes { get; set; }

            public Dictionary<byte, Node> Sons { get; set; }

            public Node(byte idSymbol, int indexSymbol)
            {
                IdSymbol = idSymbol;
                IndexSymbol = indexSymbol;
                Sons = new Dictionary<byte, Node>();
            }

            public Node IsFind(byte value)
            => Sons.TryGetValue(value, out Node node) ? node : null;
        }

        private Node root = new Node(0, 0);

        private Node runner;

        public Trie()
        {
            for (int i = 0; i < 256; ++i)
            {
                InitRoot((byte)i, i);
            }
        }

        public int CountCodes { get; set; }

        public int LastCode { get; set; }

        private void InitRoot(byte idSymbol, int index)
        {
            var son = new Node(idSymbol, index);
            root.Sons.Add(idSymbol, son);
            CountCodes++;
        }

        private void Init(byte value)
        {
            var son = new Node(value, CountCodes);
            runner.Sons.Add(value, son);
            son.CodeBytes = CountCodes;
            CountCodes++;
        }

        private bool CheckAdd(byte value, ref Node node)
            => node.IsFind(value) == null ? true : false;

        public int IsAdd(byte value)
        {
            var isCheck = CheckAdd(value, ref runner);
            if (isCheck)
            {
                var son = new Node(value, CountCodes);
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
    }
}