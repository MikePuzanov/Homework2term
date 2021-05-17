using System;
using System.Collections.Generic;
using System.Text;

namespace Hw2Calculator
{
    public static class Calculator
    {
        public static (double, bool) CalculatorExpression(string expression, IStack stack)
        {
            string number = "";
            char[] expressionArray = expression.ToCharArray(0, expression.Length);
            for (int i = 0; i < expression.Length; ++i)
            {
                if (expressionArray[i] == ' ')
                {
                    number = "";
                    continue;
                }
                if (Char.IsDigit(expressionArray[i]))
                {
                    while (i < expression.Length && expressionArray[i] != ' ')
                    {
                        number += expressionArray[i];
                        ++i;
                    }
                    stack.Push(double.Parse(number));
                    number = "";
                    continue;
                }
                if (IsOperator(expressionArray[i]))
                {
                    if (stack.IsEmpty())
                    {
                        return (0, false);
                    }
                    double lastNumber = stack.Pop();
                    if (stack.IsEmpty() || (expressionArray[i] == '/' && Math.Abs(lastNumber - 0) < 0.00001))
                    {
                        stack.ClearStack();
                        return (0, false);
                    }
                    stack.Push(lastNumber);
                    ArithmeticOperation(expressionArray[i], stack);
                }
                else
                {
                    stack.ClearStack();
                    return (0, false);
                }
            }
            if (stack.IsEmpty())
            {
                return (0, false);
            }
            var result = stack.Pop();
            if (stack.IsEmpty())
            {
                return (result, true);
            }
            stack.ClearStack();
            return (0, false);
        }

        private static bool IsOperator(char symbol)
            => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';

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
