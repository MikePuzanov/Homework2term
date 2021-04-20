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
            (var result1, var isCorrect1) = Calculator.CalculatorExpression(expresion1, stack1);
            (var result2, var isCorrect2) = Calculator.CalculatorExpression(expresion1, stack2);
            if ((result1 != 6 && isCorrect1 != true) || (result2 != 6 && isCorrect2 != true))
            {
                return false;
            }
            string expresion2 = "2 4 * 2";
            (result1, isCorrect1) = Calculator.CalculatorExpression(expresion2, stack1);
            (result2, isCorrect2) = Calculator.CalculatorExpression(expresion2, stack2);
            if (isCorrect1 != false || isCorrect2 != false)
            {
                return false;
            }
            string expresion3 = "*";
            (result1, isCorrect1) = Calculator.CalculatorExpression(expresion3, stack1);
            (result2, isCorrect2) = Calculator.CalculatorExpression(expresion3, stack2);
            return isCorrect1 == false && isCorrect2 == false;
        }
    }
}