using NUnit.Framework;
using System;

namespace hw7CalculatorWinForms.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AdditionTest()
        {
            var number = "2";
            CalculatorTools.Calculate(ref number, "5", "+");
            Assert.AreEqual(number, "7");
            number = "2";
            CalculatorTools.Calculate(ref number, "-5", "+");
            Assert.AreEqual(number, "-3");
        }

        [Test]
        public void SubtractionTest()
        {
            var number = "2";
            CalculatorTools.Calculate(ref number, "5", "-");
            Assert.AreEqual(number, "-3");
            number = "2";
            CalculatorTools.Calculate(ref number, "-5", "-");
            Assert.AreEqual(number, "7");
        }

        [Test]
        public void MultiplicationTest()
        {
            var number = "2";
            CalculatorTools.Calculate(ref number, "5", "*");
            Assert.AreEqual(number, "10");
            number = "2";
            CalculatorTools.Calculate(ref number, "-5", "*");
            Assert.AreEqual(number, "-10");
            var number1 = "-2";
            CalculatorTools.Calculate(ref number1, "-5", "*");
            Assert.AreEqual(number1, "10");
        }

        [Test]
        public void DivideTest()
        {
            var number = "10";
            CalculatorTools.Calculate(ref number, "5", "/");
            Assert.AreEqual(number, "2");
            number = "10";
            CalculatorTools.Calculate(ref number, "-5", "/");
            Assert.AreEqual(number, "-2");
        }

        [Test]
        public void DivideExceptionTest()
        {
            var number = "2";
            Assert.Throws<DivideByZeroException> (() => CalculatorTools.Calculate(ref number, "0", "/"));
        }
    }
}