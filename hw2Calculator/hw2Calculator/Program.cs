using System;

namespace Hw2Calculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - стэк на списках.");
            Console.WriteLine("2 - стэк на массиве.");
            Console.WriteLine("Ваш выбор:");
            var str = Console.ReadLine();
            if (!int.TryParse(str, out int choice))
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }
            IStack stack;
            switch (choice)
            {
                case 1:
                    stack = new StackList();
                break;
                case 2:
                    stack = new StackArray();
                break;
                default:
                    Console.WriteLine("Ошибка ввода!");
                return;
            }
            Console.WriteLine("Введите выражение в постфиксной форме: ");
            string expression = Console.ReadLine();
            (var result, var isCorrect) = Calculator.CalculatorExpression(expression, stack);
            if (!isCorrect)
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }
            Console.WriteLine("Ответ: " + result);
        }
    }
}