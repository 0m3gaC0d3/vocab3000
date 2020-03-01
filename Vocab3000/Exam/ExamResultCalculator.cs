namespace Vocab3000.Exam
{
    public class ExamResultCalculator
    {
        private int _vocabCount;

        private int _correctAnswers;

        private int _wrongAnswers;

        public ExamResultCalculator(int vocabCount)
        {
            _vocabCount = vocabCount;
        }

        public float GetCorrectAnswersInPercent()
        {
            var leftVocabs = _vocabCount - (_correctAnswers + _wrongAnswers);
            _wrongAnswers += leftVocabs;

            return (100f / (float) _vocabCount) * (float) _correctAnswers;
        }

        public void increaseCorrectAnswersByOne()
        {
            ++_correctAnswers;
        }

        public void increaseWrongAnswersByOne()
        {
            ++_wrongAnswers;
        }

        public int GetVocabCount()
        {
            return _vocabCount;
        }
    }
}