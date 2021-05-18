using System;
using System.Collections.Generic;
using System.Text;

namespace Hw3B_tree
{
    /// <summary>
    /// btree class
    /// </summary>
    public class BTree
    {
        public int MinimumDegreeOfTree { get; }

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

        public BTree(int minimumDegreeOfTree)
        {
            if (minimumDegreeOfTree < 2)
            {
                throw new ArgumentException("Минимальная степень дерева выбрана неправильно!");
            }
            MinimumDegreeOfTree = minimumDegreeOfTree;
        }

        private Node FindNode(string key)
        {
            var node = root;
            while (!node.Leaf)
            {
                for (int i = 0; i < node.CountKeys; ++i)
                {
                    if (key == node.Keys[i].key)
                    {
                        return node;
                    }
                    if (CompareKey(key, node.Keys[i].key))
                    {
                        node = node.Sons[i];
                        break;
                    }
                    if (i == node.CountKeys - 1)
                    {
                        node = node.Sons[i + 1];
                        break;
                    }
                }
            }
            for (int i = 0; i < node.CountKeys; ++i)
            {
                if (key == node.Keys[i].key)
                {
                    return node;
                }
            }
            return null;
        }

        /// <summary>
        /// checking for the presence of a key in a tree
        /// </summary>
        /// <returns>true - if key is in tree, false - if key isn't in tree</returns>
        public bool Exists(string key)
        {
            var node = FindNode(key);
            if (node == null)
            {
                return false;
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

        /// <summary>
        /// get value by key
        /// </summary>
        /// <returns>return value, if we find key and return null, if we don't find key</returns>
        public string GetValue(string key)
        {
            var node = FindNode(key);
            if (node == null)
            {
                return null;
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

        /// <summary>
        /// chenge value in tree by key
        /// </summary>
        /// <returns>return true,if we change value, and false, if we don't change</returns>
        public bool ChangeValueByKey(string key, string value)
        {
            var node = FindNode(key);
            if (node == null)
            {
                return false;
            }
            for (int i = 0; i < node.CountKeys; ++i)
            {
                if (key == node.Keys[i].key)
                {
                    node.Keys[i].value = value;
                    return true;
                }
            }
            return false;
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
            return String.Compare(key, keyInNode) < 0;
        }

        /// <summary>
        /// function of insert (key,value) in tree
        /// </summary>
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
        }

        private void Split(int index, Node node)
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

        private void InsertInNode(string key, string value, Node node)
        {
            int index = node.CountKeys - 1;
            if (node.Leaf)
            {
                while (index >= 0 && CompareKey(key, node.Keys[index].key))
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
                while (index >= 0 && CompareKey(key, node.Keys[index].key))
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

        /// <summary>
        /// finction delete (key, value) from tree
        /// </summary>
        public void Delete(string key)
        {
            var runner = root;
            if (root == null)
            {
                return;
            }
            Remove(key, ref runner);
            if (root.CountKeys == 0)
            {
                root = root.Leaf ? null : root.Sons[0];
            }
        }

        private int FindKeyIndex(string key, Node node)
        {
            var index = 0;
            while (index < node.CountKeys && CompareKey(node.Keys[index].key, key))
            {
                index++;
            }
            return index;
        }

        private void Remove(string key, ref Node cursor)
        {
            var index = FindKeyIndex(key, cursor);
            if (index < cursor.CountKeys && cursor.Keys[index].key == key)
            {
                if (cursor.Leaf)
                {
                    DeleteFromLeaf(index, cursor);
                }
                else
                {
                    DeleteFromNotLeaf(index, cursor);
                }
            }
            else
            {
                if (cursor.Leaf)
                {
                    return;
                }
                bool check = index == cursor.CountKeys;
                var helpNode = cursor.Sons[index];
                if (helpNode.CountKeys < MinimumDegreeOfTree)
                {
                    Fill(index, ref cursor);
                }
                if (check && index < cursor.CountKeys)
                {
                    cursor = cursor.Sons[index - 1];
                    Remove(key, ref cursor);
                }
                else
                {
                    cursor = cursor.Sons[index];
                    Remove(key, ref cursor);
                }
            }
        }

        private void DeleteFromLeaf(int index, Node node)
        {
            for (int i = index + 1; i < node.CountKeys; ++i)
            {
                node.Keys[i - 1] = node.Keys[i];
            }
            node.CountKeys--;
        }

        private void DeleteFromNotLeaf(int index, Node node)
        {
            string key = node.Keys[index].key;
            var cursor = node;
            if (node.Sons[index].CountKeys >= MinimumDegreeOfTree)
            {
                (string previousKey, string value) = GetPrev(index, cursor);
                node.Keys[index].key = previousKey;
                node.Keys[index].value = value;
                cursor = cursor.Sons[index];
                Remove(previousKey, ref cursor);
            }
            else if (node.Sons[index + 1].CountKeys >= MinimumDegreeOfTree)
            {
                (string succKey, string value) = GetSucc(index, cursor);
                node.Keys[index].key = succKey;
                node.Keys[index].value = value;
                cursor = node.Sons[index + 1];
                Remove(succKey, ref cursor);
            }
            else
            {
                Merge(index, ref cursor);
                cursor = node.Sons[index];
                Remove(key, ref cursor);
            }
        }

        private (string, string) GetPrev(int index, Node node)
        {
            var helpNode = node.Sons[index];
            while (!helpNode.Leaf)
            {
                helpNode = helpNode.Sons[helpNode.CountKeys];
            }
            return (helpNode.Keys[helpNode.CountKeys - 1].key, helpNode.Keys[helpNode.CountKeys - 1].value);
        }

        private (string, string) GetSucc(int index, Node node)
        {
            var helpNode = node.Sons[index + 1];
            while (!helpNode.Leaf)
            {
                helpNode = helpNode.Sons[0];
            }
            return (helpNode.Keys[0].key, helpNode.Keys[0].value);
        }

        private void Fill(int index, ref Node cursor)
        {
            if (index != 0 && cursor.Sons[index - 1].CountKeys >= MinimumDegreeOfTree)
            {
                TakeKeyInPrev(index, ref cursor);
            }
            else if (index != cursor.CountKeys && cursor.Sons[index + 1].CountKeys >= MinimumDegreeOfTree)
            {
                TakeKeyInNext(index, ref cursor);
            }
            else
            {
                if (index != cursor.CountKeys)
                {
                    Merge(index, ref cursor);
                }
                else
                {
                    Merge(index - 1, ref cursor);
                }
            }
        }

        private void TakeKeyInPrev(int index, ref Node cursor)
        {
            var child = cursor.Sons[index];
            var siblings = cursor.Sons[index - 1];
            for (int i = child.CountKeys - 1; i >= 0; --i)
            {
                child.Keys[i + 1] = child.Keys[i];
            }
            if (!child.Leaf)
            {
                for (int i = child.CountKeys; i >= 0; i--)
                {
                    child.Sons[i + 1] = child.Sons[i];
                }
            }
            child.Keys[0] = cursor.Keys[index - 1];
            if (!child.Leaf)
            {
                child.Sons[0] = siblings.Sons[siblings.CountKeys];
            }
            cursor.Keys[index - 1] = siblings.Keys[siblings.CountKeys - 1];
            child.CountKeys++;
            siblings.CountKeys--;
        }

        private void TakeKeyInNext(int index, ref Node cursor)
        {
            var child = cursor.Sons[index];
            var siblings = cursor.Sons[index + 1];
            child.Keys[child.CountKeys] = cursor.Keys[index];
            if (!child.Leaf)
            {
                child.Sons[child.CountKeys + 1] = siblings.Sons[0];
            }
            cursor.Keys[index] = siblings.Keys[0];
            for (int i = 1; i < siblings.CountKeys; ++i)
            {
                siblings.Keys[i - 1] = siblings.Keys[i];
            }
            if (!siblings.Leaf)
            {
                for (int i = 1; i <= siblings.CountKeys; ++i)
                {
                    siblings.Sons[i - 1] = siblings.Sons[i];
                }
            }
            child.CountKeys++;
            siblings.CountKeys--;
        }

        private void Merge(int index, ref Node cursor)
        {
            var child = cursor.Sons[index];
            var siblings = cursor.Sons[index + 1];
            child.Keys[MinimumDegreeOfTree - 1] = cursor.Keys[index];
            for (int i = 0; i < siblings.CountKeys; i++)
            {
                child.Keys[i + MinimumDegreeOfTree] = siblings.Keys[i];
            }
            if (!child.Leaf)
            {
                for (int i = 0; i <= siblings.CountKeys; i++)
                {
                    child.Sons[i + MinimumDegreeOfTree] = siblings.Sons[i];
                }
            }
            for (int i = index + 1; i < cursor.CountKeys; i++)
            {
                cursor.Keys[i - 1] = cursor.Keys[i];
            }
            for (int i = index + 2; i <= cursor.CountKeys; i++)
            {
                cursor.Sons[i - 1] = cursor.Sons[i];
            }
            child.CountKeys += siblings.CountKeys + 1;
            cursor.CountKeys--;
        }
    }
}