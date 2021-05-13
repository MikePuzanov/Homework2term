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
            tree.Insert("10", "10");
            tree.Insert("11", "11");
            tree.Insert("12", "12");
            tree.Insert("13", "13");
            tree.Insert("14", "14");
            tree.Insert("15", "15");
            tree.Insert("16", "16");
            tree.Insert("17", "17");
            tree.Insert("18", "18");
            tree.Delete("8");
        }
    }
}
