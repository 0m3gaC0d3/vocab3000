using System;

namespace Vocab3000.Exam
{
    public class Calculator
    {
        private int _vocabCount;

        private int _correctAnswers;

        private int _wrongAnswers;

        public Calculator(int vocabCount)
        {
            _vocabCount = vocabCount;
        }

        public double GetCorrectAnswersInPercent()
        {
            var leftVocabs = _vocabCount - (_correctAnswers + _wrongAnswers);
            _wrongAnswers += leftVocabs;
            var result = (100f / (float) _vocabCount) * (float) _correctAnswers;

            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public void increaseCorrectAnswersByOne()
        {
            ++_correctAnswers;
        }

        public void increaseWrongAnswersByOne()
        {
            ++_wrongAnswers;
        }

        public int GetCorrectAnswerCount()
        {
            return _correctAnswers;
        }

        public int GetWrongAnswerCount()
        {
            return _wrongAnswers;
        }
    }
}