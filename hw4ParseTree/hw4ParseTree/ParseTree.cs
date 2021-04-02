using System;
using System.Collections.Generic;
using System.Text;

namespace hw4ParseTree
{
    public class ParseTree
    {
        private INode root;

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
                    index++;
                }
                else if (line[index] == ' ')
                {
                    index++;
                }
                else if (line[index] == ')')
                {
                    countBrackets--;
                    index++;
                }
                else if (line[index] == '-' && char.IsDigit(line[index + 1]) || char.IsDigit(line[index]))
                {
                    var value = ReadNumber(line, ref index);
                    index++;
                    countNumber++;
                }
                else if (IsOperator(line[index]))
                {
                    countNumber--;
                    index++;
                }
                else
                {
                    return false;
                }
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
                        '+' => new Addition(line[index - 1], Build(line, ref index), Build(line, ref index)),
                        '-' => new Subtraction(line[index - 1], Build(line, ref index), Build(line, ref index)),
                        '/' => new Division(line[index - 1], Build(line, ref index), Build(line, ref index)),
                        '*' => new Multiplication(line[index - 1], Build(line, ref index), Build(line, ref index)),
                        _ => throw new Exception(),
                    };
                }
                else if (!IsCorrectSymbol(line[index]))
                {
                    throw new InvalidExpressionException();
                }
            }
			return root;
        }


        public void PrintTree()
            => root.Print();

        public double Calculate()
            => root.Calculate();
    }
}