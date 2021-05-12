using System;
using System.IO;

namespace Hw4ParseTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new ParseTree();
            var file = new StreamReader("..\\..\\..\\Expression.txt");
            var expression = file.ReadLine();
            Console.WriteLine($"Выражение - {expression}");
            try
            {
                tree.BuildTree(expression);
            }
            catch (InvalidExpressionException)
            {
                Console.WriteLine("Ошибка! Некоректный ввод выражения!");
                return;
            }

            Console.Write("Печать выражения: ");
            tree.PrintTree();
            Console.WriteLine($"\nОтвет = {tree.Calculate()}");
        }
    }
}
