using System;
using System.Collections.Generic;
using System.Text;

namespace hw3B_tree
{
    class BTree
    {
        public int MinimumDegreeOfTree { get; set; }

        class Node
        {

            public int CountKeys { get; set; }
            public (string key, string value)[] Keys { get; set; }

            public Node[] Sons { get; set; }

            public bool Leaf { get; set; }

            public Node(int minimumDegreeOfTree)
            {
                CountKeys = 0;
                Leaf = false;
                var Keys = new (string key, string value)[2 * minimumDegreeOfTree - 1];
                Sons = new Node[2 * minimumDegreeOfTree];
            }
        }

        private Node root;

        public BTree(int minimumDegreeOfTree)
        {
            MinimumDegreeOfTree = minimumDegreeOfTree;
            root = null;
        }

        public void Insert(string key, string value)
        {
            var runner = root;
            if (runner == null)
            {
                root = new Node(MinimumDegreeOfTree);
            }
            if (runner.CountKeys == (2 * MinimumDegreeOfTree) - 1)
            {
                var newRoot = new Node(MinimumDegreeOfTree);
                root = newRoot;
                newRoot.Sons[newRoot.CountKeys] = root;
                // Split function
                Split();
                // function InsertInNode
                InsertInNode(key, value);
            }
            else
            {
                InsertInNode(key, value);
            }

            private void Split()
            {

            }

            private void InsertInNode(string key, string value)
            {
                int size = root.CountKeys; // ???
                if (root.Leaf == true)
                {

                    // вставить key впорядке возрастания
                    for (int i = 0; i < size; ++i)
                    {
                        if (String.Compare(root.Keys[i].key, key) < 0)
                        {
                            var keySwap = root.Keys[i].key;
                            var valueSwap = root.Keys[i].value;
                            root.Keys[i].key = key;
                            root.Keys[i].value = value;
                            for (int j = i; j < size; ++j)
                            {
                                // дошли до вставляемого индекса, теперь надо сдвинуть оставшиеся
                            }
                        }
                    }
                }
                else
                {

                }
            }
        }

    }
}