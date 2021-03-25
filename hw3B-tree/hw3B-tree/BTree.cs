using System;
using System.Collections.Generic;
using System.Text;

namespace hw3B_tree
{
    public class BTree
    {
        public int MinimumDegreeOfTree { get; set; }

        private class Node
        {

            public int CountKeys { get; set; }
            public (string key, string value)[] Keys { get; set; }

            public Node[] Sons { get; set; }

            public bool Leaf { get; set; }

            public Node(int minimumDegreeOfTree, bool leaf)
            {
                CountKeys = 0;
                Leaf = leaf;
                Keys = new (string key, string value)[2 * minimumDegreeOfTree - 1];
                Sons = new Node[2 * minimumDegreeOfTree];
            }
        }

        private Node root;

        private Node runner;

        public BTree(int minimumDegreeOfTree)
        {
            if (minimumDegreeOfTree < 2)
            {
                throw new ArgumentException("Минимальная степень дерева выбрана неправильна!");
            }
            MinimumDegreeOfTree = minimumDegreeOfTree;
        }

        public bool IsConsist(string key)
        {
            var node = root;
            while (!node.Leaf)
            {
                for (int i = 0; i < node.CountKeys; ++i)
                {
                    if (key == node.Keys[i].key)
                    {
                        return true;
                    }
                    if (CompareKey(key, node.Keys[i].key))
                    {
                        node = node.Sons[i];
                        break;
                    }
                    if (i == node.CountKeys - 1)
                    {
                        node = node.Sons[i + 1];
                    }
                }
            }
            for (int i = 0; i < node.CountKeys; ++i)
            {
                if (key == node.Keys[i].key)
                {
                    return true;
                }
            }
            return false;
        }
        

        public string GetValue(string key)
        {
            var node = root;
            while (!node.Leaf)
            {
                for (int i = 0; i < node.CountKeys; ++i)
                {
                    if (key == node.Keys[i].key)
                    {
                        return node.Keys[i].value;
                    }
                    if (CompareKey(key, node.Keys[i].key))
                    {
                        node = node.Sons[i];
                        break;
                    }
                    if (i == node.CountKeys - 1)
                    {
                        node = node.Sons[i + 1];
                    }
                }
            }
            for (int i = 0; i < node.CountKeys; ++i)
            {
                if (key == node.Keys[i].key)
                {
                    return node.Keys[i].value;
                }
            }
            return null;
        }

        public bool CompareKey(string key, string keyInNode)
        {
            if (key.Length < keyInNode.Length)
            {
                return true;
            }
            else if (key.Length > keyInNode.Length)
            {
                return false;
            }
            return String.Compare(key, keyInNode) < 0 ? true : false;
        }

        public void Insert(string key, string value)
        {
            var runner = root;
            if (root == null)
            {
                root = new Node(MinimumDegreeOfTree, true);
                root.Keys[0].key = key;
                root.Keys[0].value = value;
                root.CountKeys++;
            }
            else if (root.CountKeys == (2 * MinimumDegreeOfTree) - 1)
            {
                var newRoot = new Node(MinimumDegreeOfTree, false);
                newRoot.Sons[newRoot.CountKeys] = root;
                root = newRoot;
                Split(0, root);
                InsertInNode(key, value, root);
            }
            else
            {
                InsertInNode(key, value, runner);
            }

             void Split(int index, Node node)
            {
                var helpNode = node.Sons[index];
                var newNode = new Node(MinimumDegreeOfTree, helpNode.Leaf);
                newNode.CountKeys = MinimumDegreeOfTree - 1;
                Array.Copy(helpNode.Keys, MinimumDegreeOfTree, newNode.Keys, 0, MinimumDegreeOfTree - 1);
                if (!node.Leaf)
                {
                    Array.Copy(helpNode.Sons, MinimumDegreeOfTree, newNode.Sons, 0, MinimumDegreeOfTree);
                }
                helpNode.CountKeys = MinimumDegreeOfTree - 1;
                for (int i = node.CountKeys; i >= index + 1; i--)
                {
                    node.Sons[i + 1] = node.Sons[i];
                }
                node.Sons[index + 1] = newNode;
                for (int i = node.CountKeys - 1; i >= index; i--)
                {
                    node.Keys[i + 1].key = node.Keys[i].key;
                    node.Keys[i + 1].value = node.Keys[i].value;
                }
                node.Keys[index].key = helpNode.Keys[MinimumDegreeOfTree - 1].key;
                node.Keys[index].value = helpNode.Keys[MinimumDegreeOfTree - 1].value;
                node.CountKeys++;
            }

            void InsertInNode(string key, string value, Node node)
            {
                int size = node.CountKeys; //
                int index = size - 1;
                if (node.Leaf)
                {
                    while (index >= 0 && CompareKey(key, node.Keys[index].key)) // проверитб сравнение
                    {
                        node.Keys[index + 1].key = node.Keys[index].key;
                        node.Keys[index + 1].value = node.Keys[index].value;
                        index--;
                    }
                    node.Keys[index + 1].key = key;
                    node.Keys[index + 1].value = value;
                    node.CountKeys++;
                }
                else
                {
                    while (index >= 0 && CompareKey(key, node.Keys[index].key)) // проверитб сравнение
                    {
                        index--;
                    }
                    index++;
                    if (node.Sons[index].CountKeys == (2 * MinimumDegreeOfTree - 1))
                    {
                        Split(index, node);
                        if (!CompareKey(key, node.Keys[index].key))
                        {
                            index++;
                        }
                    }
                    InsertInNode(key, value, node.Sons[index]);
                }   
            }

        }

    }
}