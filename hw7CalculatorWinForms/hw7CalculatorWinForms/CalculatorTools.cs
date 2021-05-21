using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw7CalculatorWinForms
{
    static public class CalculatorTools
    {
        static public void Calculate(ref double str1, double str2, string sign)
        {
            switch (sign)
            {
                case "+":
                    str1 = str1 + str2;
                    break;
                case "-":
                    str1 = str1 - str2;
                    break;
                case "*":
                    str1 = str1 * str2;
                    break;
                case "/":
                    if (str2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    str1 = str1 / str2;
                    break;
            }
        }
    }
}
