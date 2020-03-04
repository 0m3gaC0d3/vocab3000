using NUnit.Framework;
using Vocab3000.Exam;
using System;

namespace Tests.Exam
{
    public class CalculatorTest
    {
        [Test]
        public void AllAnswersRightResultIn100Percent()
        {
            double expectedPercent = 100f;
            var vocabCount = 10;
            var calculator = new Calculator(vocabCount);
            for (int i = 0; i < vocabCount; ++i)
            {
                calculator.increaseCorrectAnswersByOne();
            }
            Assert.AreEqual(expectedPercent, calculator.GetCorrectAnswersInPercent());
        }

        [Test]
        public void AllAnswersWrongResultIn0Percent()
        {
            double expectedPercent = 0f;
            var vocabCount = 10;
            var calculator = new Calculator(vocabCount);
            for (int i = 0; i < vocabCount; ++i)
            {
                calculator.increaseWrongAnswersByOne();
            }
            Assert.AreEqual(expectedPercent, calculator.GetCorrectAnswersInPercent());
        }

        [Test]
        public void HalfAnswersRightHalfAnswersWrongResultIn50Percent()
        {
            double expectedPercent = 50f;
            var vocabCount = 10;
            var calculator = new Calculator(vocabCount);
            for (int i = 0; i < vocabCount; ++i)
            {
                if (i > 4)
                {
                    calculator.increaseCorrectAnswersByOne();
                }
                else
                {
                    calculator.increaseWrongAnswersByOne();
                }

            }
            Assert.AreEqual(expectedPercent, calculator.GetCorrectAnswersInPercent());
        }

        [Test]
        public void OneThirdAnswersRightResultIn33_33Percent()
        {
            double expectedPercent = Math.Round(33.33f, 2, MidpointRounding.AwayFromZero);
            var vocabCount = 3;
            var calculator = new Calculator(vocabCount);
            calculator.increaseCorrectAnswersByOne();
            calculator.increaseWrongAnswersByOne();
            calculator.increaseWrongAnswersByOne();
            Assert.AreEqual(expectedPercent, calculator.GetCorrectAnswersInPercent());
        }
    }
}