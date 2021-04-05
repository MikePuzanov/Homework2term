using System;
using System.Linq;

namespace hw1BWT
{
    class Program
    {
        static void Main()
        {
            if (!BWT.Test())
            {
                Console.WriteLine("Тест не пройден!");
                return;
            }
            Console.WriteLine("Тест пройден!");
            Console.WriteLine("Введите строку: ");
            string line = Console.ReadLine();
            var (result, numberOfString) = BWT.BWTtransform(line);
            Console.WriteLine("Строка после алгоритма: " + result);
            string res2 = BWT.ReverseBWT(result, numberOfString);
            Console.WriteLine("Исходная строка: " + res2);
        }
    }
}