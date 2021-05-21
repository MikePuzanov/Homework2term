using NUnit.Framework;
using System;

namespace Hw7CalculatorWinForms.Test
{
    public class Tests
    {
        [Test]
        public void AdditionTest()
        {
            double number = 2;
            CalculatorTools.Calculate(ref number, 5, "+");
            Assert.AreEqual(number, 7);
            number = 2;
            CalculatorTools.Calculate(ref number, -5, "+");
            Assert.AreEqual(number, -3);
        }

        [Test]
        public void SubtractionTest()
        {
            double number = 2;
            CalculatorTools.Calculate(ref number, 5, "-");
            Assert.AreEqual(number, -3);
            number = 2;
            CalculatorTools.Calculate(ref number, -5, "-");
            Assert.AreEqual(number, 7);
        }

        [Test]
        public void MultiplicationTest()
        {
            var number = 2.0;
            CalculatorTools.Calculate(ref number, 5, "*");
            Assert.AreEqual(number, 10);
            number = 2;
            CalculatorTools.Calculate(ref number, -5, "*");
            Assert.AreEqual(number, -10);
            var number1 = -2.0;
            CalculatorTools.Calculate(ref number1, -5, "*");
            Assert.AreEqual(number1, 10);
        }

        [Test]
        public void DivideTest()
        {
            var number = 10.0;
            CalculatorTools.Calculate(ref number, 5, "/");
            Assert.AreEqual(number, 2);
            number = 10;
            CalculatorTools.Calculate(ref number, -5, "/");
            Assert.AreEqual(number, -2);
        }

        [Test]
        public void DivideExceptionTest()
        {
            var number = 2.0;
            Assert.Throws<DivideByZeroException> (() => CalculatorTools.Calculate(ref number, 0, "/"));
        }
    }
}