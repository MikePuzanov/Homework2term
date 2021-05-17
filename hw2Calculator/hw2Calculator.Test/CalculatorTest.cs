using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Hw2Calculator.Test
{
    public class CalculatorTests
    {
        private bool CheckTrueExpression(bool isCorrect, double result, double mainResult)
        {
            return !isCorrect || Math.Abs(result - mainResult) < 0.000001;
        }

        private static (string Test, double Result)[] CorrectDataForTests = new[]
        {
            ("2 4 * 2 -", 6.0),
            ("2 2 +", 4.0),
            ("16 5 -", 11.0),
            ("5 5 *", 25.0),
            ("5 -5 *", -25.0),
            ("-5 -5 *", 25),
            ("25 5 /", 5),
            ("25 -5 /", -5),
            ("-25 -5 /", 5),
            ("-25 -5 /", 5),
            ("-25 -5 /", 5),
            ("1 2 + 5 2 - *", 9),
            ("6 3 - 1 2 * /", 1.5),
        };

        [TestCaseSource(nameof(CorrectDataForTest))]
        public void CalculatorTestForCorrectData(IStack stack, string expresion, double mainResult)
        {
            (var result, var isCorrect) = Calculator.CalculatorExpression(expresion, stack);
            Assert.IsTrue(CheckTrueExpression(isCorrect, result, mainResult));
        }

        private static IEnumerable<TestCaseData> CorrectDataForTest
            =>
                CorrectDataForTests.SelectMany(DataForTests => new TestCaseData[]
                {
                    new TestCaseData(new StackList(), DataForTests.Test, DataForTests.Result),
                    new TestCaseData(new StackArray(), DataForTests.Test, DataForTests.Result)
                });

        private static string[] UncorrectDataForTests = new[]
        {
            ("2 + 2"),
            ("2 / 0"),
            ("2 +"),
            ("2 asd"),
            ("2 2 + 2"),
        };

        [TestCaseSource(nameof(CorrectDataForTest))]
        public void CalculatorTestForUncorrectData(IStack stack, string expresion, double mainResult)
        {
            (var result, var isCorrect) = Calculator.CalculatorExpression(expresion, stack);
            Assert.IsTrue(CheckTrueExpression(isCorrect, result, mainResult));
        }

        private static IEnumerable<TestCaseData> UncorrectDataForTest
            =>
                UncorrectDataForTests.SelectMany(DataForTests => new TestCaseData[]
                {
                    new TestCaseData(new StackList(), UncorrectDataForTests),
                    new TestCaseData(new StackArray(), UncorrectDataForTests)
                });
    }
}