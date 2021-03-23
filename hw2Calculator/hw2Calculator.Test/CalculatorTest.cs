using NUnit.Framework;

namespace hw2Calculator.Test
{
    public class Tests
    {
        private bool CheckTrueExpression(bool isCorrect1, bool isCorrect2, double result1, double result2, double mainResult)
        {
            if ((!isCorrect1 || !isCorrect2) || (result1 != mainResult || result2 != mainResult))
            {
                return false;
            }
            return true;
        }

        private bool CheckFalseExpression(bool isCorrect1, bool isCorrect2)
        {
            return (!isCorrect1 && !isCorrect2);
        }

        [TestCase]
        public void TestTrueExpression()
        {
            string expresion = "2 4 * 2 -";
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            bool isCorrect1 = false;
            bool isCorrect2 = false;
            var result1 = Calculator.CalculatorExpression(expresion, ref isCorrect1, stack1);
            var result2 = Calculator.CalculatorExpression(expresion, ref isCorrect2, stack2);
            Assert.IsTrue(CheckTrueExpression(isCorrect1, isCorrect2, result1, result2, 6.0));
        }

        [TestCase]
        public void TestFalseExpression()
        {
            string expresion = "2 4 * 2";
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            bool isCorrect1 = false;
            bool isCorrect2 = false;
            Calculator.CalculatorExpression(expresion, ref isCorrect1, stack1);
            Calculator.CalculatorExpression(expresion, ref isCorrect2, stack2);
            Assert.IsTrue(CheckFalseExpression(isCorrect1, isCorrect2));
        }

        [TestCase]
        public void TestDivisionByZero()
        {
            string expresion = "2 0 /";
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            bool isCorrect1 = false;
            bool isCorrect2 = false;
            Calculator.CalculatorExpression(expresion, ref isCorrect1, stack1);
            Calculator.CalculatorExpression(expresion, ref isCorrect2, stack2);
            Assert.IsTrue(CheckFalseExpression(isCorrect1, isCorrect2));
        }
    }
}