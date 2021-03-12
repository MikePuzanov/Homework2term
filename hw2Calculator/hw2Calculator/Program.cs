using System;

namespace hw2Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Test.TestCalculator())
            {
                Console.WriteLine("Тест не пройден");
                return;
            }
            Console.WriteLine("Тест пройден");
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - стэк на списках.");
            Console.WriteLine("2 - стэк на массиве.");
            Console.WriteLine("Ваш выбор:");
            var str = Console.ReadLine();
            if (!int.TryParse(str, out int choice))
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }
            IStack stack;
            if (choice == 1)
            {
                stack = new StackList();
            }
            else if (choice == 2)
            {
                stack = new StackArray();
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }
            Console.WriteLine("Введите выражение в постфиксной форме: ");
            string expression = Console.ReadLine();
            bool isCorrect = false;
            var result = Calculator.CalculatorExpression(expression, ref isCorrect, stack);
            if (!isCorrect)
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }
            Console.WriteLine("Ответ: " + result);
        }
    }
}