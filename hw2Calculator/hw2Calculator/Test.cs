using System;
using System.Collections.Generic;
using System.Text;

namespace hw2Calculator
{
    class Test
    {
        public static bool TestCalculator()
        {
            string expresion1 = "2 4 * 2 -";
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            bool isCorrect1 = false;
            bool isCorrect2 = false;
            if ((Calculator.CalculatorExpression(expresion1, ref isCorrect1, stack1) != 6 && isCorrect1 != true) || (Calculator.CalculatorExpression(expresion1, ref isCorrect2, stack2) != 6 && isCorrect2 != true))
            {
                return false;
            }
            string expresion2 = "2 4 * 2";
            Calculator.CalculatorExpression(expresion2, ref isCorrect1, stack1);
            Calculator.CalculatorExpression(expresion2, ref isCorrect2, stack2);
            if (isCorrect1 != false || isCorrect2 != false)
            {
                return false;
            }
            string expresion3 = "*";
            Calculator.CalculatorExpression(expresion3, ref isCorrect1, stack1);
            Calculator.CalculatorExpression(expresion3, ref isCorrect2, stack2);
            if (isCorrect1 != false || isCorrect2 != false)
            {
                return false;
            }
            return true;
        }
    }
}