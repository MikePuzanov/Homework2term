using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw7CalculatorWinForms
{
    public partial class CalculatorForms : Form
    {
        private string NumberFirst = "";

        private string NumberSecond = "";

        private int CountNumber = 0;

        private string Operator = "";

        private bool IsMinus = false;

        public CalculatorForms()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Operator != "")
            {
                CountNumber = 1;
            }
            if (CountNumber == 0)
            {
                NumberFirst += (sender as Button).Text;
                buttonText.Text = NumberFirst;
            }
            else
            {
                NumberSecond += (sender as Button).Text;
                buttonText.Text = NumberSecond;
            }
        }

        private void buttonPlusMinus_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsMinus)
            {
                if (CountNumber == 0)
                {
                    NumberFirst = "-" + NumberFirst;
                    buttonText.Text = NumberFirst;
                }
                else
                {
                    NumberSecond = "-" + NumberSecond;
                    buttonText.Text = NumberSecond;
                }
            }
            else
            {
                if (CountNumber == 0)
                {
                    NumberFirst = NumberFirst.Substring(1);
                    buttonText.Text = NumberFirst;
                }
                else
                {
                    NumberSecond = NumberSecond.Substring(1);
                    buttonText.Text = NumberSecond;
                }
            }
            IsMinus = !IsMinus;
        }

        private void buttonPlus_MouseClick(object sender, MouseEventArgs e)
        {
            Operator = (sender as Button).Text;
            if (NumberFirst != "" && NumberSecond != "")
            {
                CalculatorTools.Calculate(ref NumberFirst, NumberSecond, Operator);
                Operator = NumberSecond = "";
                CountNumber = 1;
                buttonText.Text = NumberFirst;
            }
        }


        private void buttonEqual_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                CalculatorTools.Calculate(ref NumberFirst, NumberSecond, Operator);
            }
            catch (DivideByZeroException)
            {
                NumberFirst = NumberSecond = Operator = "";
                buttonText.Text = "Error";
                CountNumber = 0;
                return;
            }
            NumberSecond = Operator = "";
            CountNumber = 1;
            buttonText.Text = NumberFirst;
        }

        private void buttonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            if (Operator == "")
            {
                if (NumberFirst.Length == 0)
                {
                    return;
                }
                NumberFirst = NumberFirst.Substring(0, NumberFirst.Length - 1);
                buttonText.Text = NumberFirst;
            }
            else
            {
                if (NumberSecond.Length == 0)
                {
                    return;
                }
                NumberSecond = NumberSecond.Substring(0, NumberSecond.Length - 1);
                buttonText.Text = NumberSecond;
            }
        }

        private void buttonResetAll_MouseClick(object sender, MouseEventArgs e)
        {
            NumberFirst = NumberSecond = Operator = "";
            CountNumber = 0;
            buttonText.Text = "0";
        }

        private void buttonResetString_MouseClick(object sender, MouseEventArgs e)
        {
            if (Operator == "")
            {
                NumberFirst = NumberSecond = Operator = "";
                CountNumber = 0;
                buttonText.Text = "0";
            }
            else
            {
                NumberSecond = "";
                buttonText.Text = NumberFirst;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
