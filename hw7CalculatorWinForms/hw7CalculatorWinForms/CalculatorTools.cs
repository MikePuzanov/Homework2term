using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw7CalculatorWinForms
{
    /// <summary>
    /// класс для подсчета значений
    /// </summary>
    static public class CalculatorTools
    {
        /// <summary>
        /// Считает значение двух чисел по знаку
        /// </summary>
        /// <param name="number1">первое число</param>
        /// <param name="number2">второе число</param>
        /// <param name="sign">арифмитический знак</param>
        static public void Calculate(ref double number1, double number2, string sign)
        {
            switch (sign)
            {
                case "+":
                    number1 = number1 + number2;
                    break;
                case "-":
                    number1 = number1 - number2;
                    break;
                case "*":
                    number1 = number1 * number2;
                    break;
                case "/":
                    if (number2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    number1 = number1 / number2;
                    break;
            }
        }
    }
}
