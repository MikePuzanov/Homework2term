using System;

namespace Hw3B_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BTree(2);
            tree.Insert("1", "1");
            tree.Insert("2", "2");
            tree.Insert("3", "3");
            tree.Insert("4", "4");
            tree.Insert("5", "5");
            tree.Insert("6", "6");
            tree.Insert("7", "7");
            tree.Insert("8", "8");
            tree.Insert("9", "9");
        }
    }
}