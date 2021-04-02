using System;

namespace hw4ParseTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new ParseTree();
            Console.WriteLine("Введите выражение -");
            var expression = Console.ReadLine();
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
