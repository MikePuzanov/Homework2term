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

            public Node(int minimumDegreeOfTree, bool leaf)
            {
                CountKeys = 0;
                Leaf = leaf;
                var Keys = new (string key, string value)[2 * minimumDegreeOfTree - 1];
                Sons = new Node[2 * minimumDegreeOfTree];
            }
        }

        private Node root;

        private Node runner;

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
                root = new Node(MinimumDegreeOfTree, true);
            }
            if (runner.CountKeys == (2 * MinimumDegreeOfTree) - 1)
            {
                var newRoot = new Node(MinimumDegreeOfTree, false);
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

             void Split(int index, Node node)// разобраться со split
            {
                var newNode = new Node(MinimumDegreeOfTree, runner.Leaf);
                newNode.CountKeys = MinimumDegreeOfTree - 1;
                Array.Copy(runner.Keys, MinimumDegreeOfTree, newNode.Keys, 0, MinimumDegreeOfTree - 1);
                if (!runner.Leaf)
                {
                    Array.Copy(runner.Sons, MinimumDegreeOfTree, newNode.Sons, 0, MinimumDegreeOfTree);
                }
                runner.CountKeys = MinimumDegreeOfTree - 1;
            }

            void InsertInNode(string key, string value)
            {
                int size = runner.CountKeys; //
                int index = size - 1;
                if (runner.Leaf == true)
                {
                    while (index >= 0 && String.Compare(runner.Keys[index].key, key) < 0) // проверитб сравнение
                    {
                        runner.Keys[index + 1].key = runner.Keys[index].key;
                        runner.Keys[index + 1].value = runner.Keys[index].value;
                        index--;
                    }
                    runner.Keys[index + 1].key = key;
                    runner.Keys[index + 1].value = value;
                    runner.CountKeys++;
                }
                else
                {
                    while (index >= 0 && String.Compare(root.Keys[index].key, key) < 0) // проверитб сравнение
                    {
                        index--;
                    }
                    if (root.Sons[index].CountKeys == (2 * MinimumDegreeOfTree - 1))
                    {
                        Split();
                        if (String.Compare(root.Keys[index].key, key) < 0) // проверитб сравнение
                        {
                            index++;
                        }
                    }
                    runner = runner.Sons[index + 1];
                    InsertInNode(key, value);
                }   
            }
        }

    }
}