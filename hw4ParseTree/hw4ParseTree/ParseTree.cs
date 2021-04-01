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
            var line = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var index = 0;
            if (IsCorrect(line[0]))
            {
                root = Build(line, ref index);
            }
            else
            {
                throw new InvalidExpressionException(); 
            }
        }

        private bool IsCorrectSymbol(string symbol)
            => symbol == "(" || symbol == ")";

        private bool IsCorrect(string symbol)
            => symbol == "(" || IsOperator(symbol);

        private INode Build(string[] line, ref int index)
        {
            for (; index < line.Length; ++index)
            {
                if (IsOperator(line[index]))
                {
                    index++;
                    return line[index - 1] switch
                    {
                        "+" => new Addition(line[index - 1], Build(line, ref index), Build(line, ref index)),
                        "-" => new Subtraction(line[index - 1], Build(line, ref index), Build(line, ref index)),
                        "/" => new Division(line[index - 1], Build(line, ref index), Build(line, ref index)),
                        "*" => new Multiplication(line[index - 1], Build(line, ref index), Build(line, ref index)),
                        _ => throw new Exception(),
                    };
                }
                else if (double.TryParse(line[index], out var value))
                {
                    index++;
                    return new Operand(value);
                }
                else if (!IsCorrectSymbol(line[index]))
                {
                    throw new InvalidExpressionException();
                }
            }
			return root;
        }

        private bool IsOperator(string symbol)
            => symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";

        public void PrintTree()
            => root.Print();

        public double Calculate()
            => root.Calculate();
    }
}