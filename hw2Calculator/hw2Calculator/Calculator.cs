using System;
using System.Collections.Generic;
using System.Text;

namespace hw2Calculator
{
    public static class Calculator
    {
        public static double CalculatorExpression(string expression, ref bool IsCorrect, IStack stack)
        {
            string number = "";
            char[] experssionArray = expression.ToCharArray(0, expression.Length);
            for (int i = 0; i < expression.Length; ++i)
            {
                if (experssionArray[i] == ' ')
                {
                    number = "";
                    continue;
                }
                if (Char.IsDigit(experssionArray[i]))
                {
                    while (i < expression.Length && experssionArray[i] != ' ')
                    {
                        number += experssionArray[i];
                        ++i;
                    }
                    stack.Push(double.Parse(number));
                    number = "";
                    continue;
                }
                if (IsOperand(experssionArray[i]))
                {
                    if (stack.IsEmpty())
                    {
                        IsCorrect = false;
                        return 0;
                    }
                    double lastNumber = stack.Pop();
                    if (stack.IsEmpty() ||  (experssionArray[i] == '/' && Math.Abs(lastNumber - 0) < 0.00001))
                    {
                        stack.DeleteStack();
                        IsCorrect = false;
                        return 0;
                    }
                    stack.Push(lastNumber);
                    ArithmeticOperation(experssionArray[i], stack);
                }
                else
                {
                    stack.DeleteStack();
                    IsCorrect = false;
                    return 0;
                }
            }
            if (stack.IsEmpty())
            {
                IsCorrect = false;
                return 0;
            }
            var result = stack.Pop();
            if (stack.IsEmpty())
            {
                IsCorrect = true;
                return result;
            }
            stack.DeleteStack();
            IsCorrect = false;
            return 0;
        }

        private static bool IsOperand(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
        }

        private static void ArithmeticOperation(char operation, IStack stack)
        {
            var number2 = stack.Pop();
            var number1 = stack.Pop();
            switch (operation)
            {
                case '+':
                    stack.Push(number1 + number2);
                    break;
                case '-':
                    stack.Push(number1 - number2);
                    break;
                case '*':
                    stack.Push(number1 * number2);
                    break;
                case '/':
                    stack.Push(number1 / number2);
                    break;
            }
        }
    }
}
