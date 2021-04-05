using System;

namespace hw4UniqueList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();
            list.Insert(0, 2);
            list.Insert(1, 4);
            list.Insert(2, 7);
            list.Insert(3, 8);
            list.Insert(2, 6);
            list.Insert(1, 3);
            list.Insert(0, 1);
            list.Insert(4, 5);
            list.DeleteByValue(2);
            list.DeleteByValue(7);
            list.DeleteByValue(1);
        }
    }
}
