using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hw7CalculatorWinForms
{
    /// <summary>
    /// класс с интерфейс калькулятора
    /// </summary>
    public partial class CalculatorForms : Form
    {
        private string numberFirst = "";

        private string numberSecond = "";

        private int countNumber = 0;

        private string sign = "";

        private bool isMinus = false;

        public CalculatorForms()
            => InitializeComponent();

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (sign != "")
            {
                countNumber = 1;
            }
            if (countNumber == 0)
            {
                numberFirst += (sender as Button).Text;
                buttonText.Text = numberFirst;
            }
            else
            {
                numberSecond += (sender as Button).Text;
                buttonText.Text = numberSecond;
            }
        }

        private void buttonPlusMinus_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isMinus)
            {
                if (countNumber == 0)
                {
                    numberFirst = "-" + numberFirst;
                    buttonText.Text = numberFirst;
                }
                else
                {
                    numberSecond = "-" + numberSecond;
                    buttonText.Text = numberSecond;
                }
            }
            else
            {
                if (countNumber == 0)
                {
                    numberFirst = numberFirst.Substring(1);
                    buttonText.Text = numberFirst;
                }
                else
                {
                    numberSecond = numberSecond.Substring(1);
                    buttonText.Text = numberSecond;
                }
            }
            isMinus = !isMinus;
        }

        private void buttonSign_MouseClick(object sender, MouseEventArgs e)
        {
            sign = (sender as Button).Text;
            if (numberFirst != "" && numberSecond != "")
            {
                double number1 = double.Parse(numberFirst);
                double number2 = double.Parse(numberSecond);
                CalculatorTools.Calculate(ref number1, number2, sign);
                numberFirst = Convert.ToString(number1);
                numberSecond = "";
                sign = "";
                countNumber = 1;
                buttonText.Text = numberFirst;
            }
        }

        private void buttonEqual_MouseClick(object sender, MouseEventArgs e)
        {
            double number1 = double.Parse(numberFirst);
            double number2 = double.Parse(numberSecond);
            try
            {
                CalculatorTools.Calculate(ref number1, number2, sign);
            }
            catch (DivideByZeroException)
            {
                numberFirst ="";
                numberSecond = "";
                sign = "";
                buttonText.Text = "Error";
                countNumber = 0;
                return;
            }
            numberFirst = Convert.ToString(number1);
            numberSecond = "";
            sign = "";
            countNumber = 1;
            buttonText.Text = numberFirst;
        }

        private void buttonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            if (sign == "")
            {
                if (numberFirst.Length == 0)
                {
                    return;
                }
                numberFirst = numberFirst.Substring(0, numberFirst.Length - 1);
                buttonText.Text = numberFirst;
                if (numberFirst == "")
                {
                    isMinus = false;
                }
            }
            else
            {
                if (numberSecond.Length == 0)
                {
                    return;
                }
                numberSecond = numberSecond.Substring(0, numberSecond.Length - 1);
                buttonText.Text = numberSecond;
                if (numberSecond == "")
                {
                    isMinus = false;
                }
            }
        }

        private void buttonResetAll_MouseClick(object sender, MouseEventArgs e)
        {
            numberFirst = "";
            numberSecond = "";
            sign = "";
            countNumber = 0;
            isMinus = false;
            buttonText.Text = "0";
        }

        private void buttonResetString_MouseClick(object sender, MouseEventArgs e)
        {
            if (sign == "")
            {
                numberFirst = numberSecond = sign = "";
                countNumber = 0;
                buttonText.Text = "0";
                isMinus = false;
            }
            else
            {
                isMinus = false;
                numberSecond = "";
                buttonText.Text = numberFirst;
            }
        }
    }
}
