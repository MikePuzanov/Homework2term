using NUnit.Framework;

namespace hw2Calculator.Test
{
    public class Tests
    {
        private bool CheckTrueExpression(bool isCorrect1, bool isCorrect2, double result1, double result2, double mainResult)
        {
            return (!isCorrect1 || !isCorrect2) || (result1 - mainResult < 0.000001 || result2 - mainResult < 0.000001);
        }

        private bool CheckFalseExpression(bool isCorrect1, bool isCorrect2)
        {
            return (!isCorrect1 && !isCorrect2);
        }

        [Test]
        public void TestTrueExpression()
        {
            string expresion = "2 4 * 2 -";
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            (var result1, var isCorrect1) = Calculator.CalculatorExpression(expresion, stack1);
            (var result2, var isCorrect2) = Calculator.CalculatorExpression(expresion, stack2);
            Assert.IsTrue(CheckTrueExpression(isCorrect1, isCorrect2, result1, result2, 6.0));
        }

        [Test]
        public void TestFalseExpression()
        {
            string expresion = "2 4 * 2";
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            (var result1, var isCorrect1) = Calculator.CalculatorExpression(expresion, stack1);
            (var result2, var isCorrect2) = Calculator.CalculatorExpression(expresion, stack2);
            Assert.IsTrue(CheckFalseExpression(isCorrect1, isCorrect2));
        }

        [Test]
        public void TestDivisionByZero()
        {
            string expresion = "2 0 /";
            IStack stack1 = new StackList();
            IStack stack2 = new StackArray();
            (var result1, var isCorrect1) = Calculator.CalculatorExpression(expresion, stack1);
            (var result2, var isCorrect2) = Calculator.CalculatorExpression(expresion, stack2);
            Assert.IsTrue(CheckFalseExpression(isCorrect1, isCorrect2));
        }
    }
}