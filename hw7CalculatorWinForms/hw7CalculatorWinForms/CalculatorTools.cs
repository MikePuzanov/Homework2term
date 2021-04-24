using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7CalculatorWinForms
{
    static public class CalculatorTools
    {
        static public void Calculate(ref string str1, string str2, string sign)
        {
            switch (sign)
            {
                case "+":
                    str1 = Convert.ToString(double.Parse(str1) + double.Parse(str2));
                    break;
                case "-":
                    str1 = Convert.ToString(double.Parse(str1) - double.Parse(str2));
                    break;
                case "*":
                    str1 = Convert.ToString(double.Parse(str1) * double.Parse(str2));
                    break;
                case "/":
                    if (double.Parse(str2) == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    str1 = Convert.ToString(double.Parse(str1) / double.Parse(str2));
                    break;
            }
        }
    }
}
