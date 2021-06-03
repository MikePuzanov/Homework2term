using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4ParseTree
{
    /// <summary>
    /// дерево разбора
    /// </summary>
    public class ParseTree
    {
        private INode root;

        /// <summary>
        /// Функция построения дерева разбора
        /// </summary>
        public void BuildTree(string expression)
        {
            var index = 0;
            if (CheckExpression(expression))
            {
                root = Build(expression, ref index);
            }
            else
            {
                throw new InvalidExpressionException(); 
            }
        }

        private bool IsCorrectSymbol(char symbol)
            => symbol == '(' || symbol == ')';

        private bool IsCorrect(char symbol)
            => symbol == '(' || IsOperator(symbol);
        
        private bool IsOperator(char symbol)
            => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';

        private double ReadNumber(string line, ref int index)
        {
            var number = "";
            if (line[index] == '-')
            {
                number += line[index];
                index++;
            }
            while (char.IsDigit(line[index]))
            {
                number += line[index];
                index++;
            }
            if (!double.TryParse(number, out var value))
            {
                throw new InvalidExpressionException();
            }
            return value;
        }

        private bool CheckExpression(string line)
        {
            int index = 0;
            int countNumber = 0;
            int countBrackets = 0;
            while (index != line.Length)
            {
                if (line[index] == '(')
                {
                    countBrackets++;
                }
                else if (line[index] == ' ')
                {
                    index++;
                    continue;
                }
                else if (line[index] == ')')
                {
                    countBrackets--;
                    if (countBrackets < 0)
                    {
                        return false;
                    }
                }
                else if (line[index] == '-' && char.IsDigit(line[index + 1]) || char.IsDigit(line[index]))
                {
                    var value = ReadNumber(line, ref index);
                    countNumber++;
                    continue;
                }
                else if (IsOperator(line[index]))
                {
                    countNumber--;
                }
                else
                {
                    return false;
                }
                index++;
            }
            return countBrackets == 0 && countNumber == 1;
        }

        private INode Build(string line, ref int index)
        {
            for (; index < line.Length; ++index)
            {
                if (line[index] == ' ')
                {
                    continue;
                }
                if (line[index] == '-' && char.IsDigit(line[index + 1]) || char.IsDigit(line[index]))
                {
                    var value = ReadNumber(line, ref index);
                    return new Operand(value);
                }
                else if (IsOperator(line[index]))
                {
                    index++;
                    return line[index - 1] switch
                    {
                        '+' => new Addition(Build(line, ref index), Build(line, ref index)),
                        '-' => new Subtraction(Build(line, ref index), Build(line, ref index)),
                        '/' => new Division(Build(line, ref index), Build(line, ref index)),
                        '*' => new Multiplication(Build(line, ref index), Build(line, ref index)),
                        _ => throw new InvalidExpressionException(),
                    };
                }
                else if (!IsCorrectSymbol(line[index]))
                {
                    throw new InvalidExpressionException();
                }
            }
            return root;
        }


        /// <summary>
        /// функция печати дерева
        /// </summary>
        public void PrintTree()
            => root.Print();

        /// <summary>
        /// Считает значение выражения
        /// </summary>
        /// <returns>возвращает ответ</returns>
        public double Calculate()
            => root.Calculate();
    }
}