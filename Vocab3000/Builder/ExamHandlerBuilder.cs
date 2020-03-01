using Vocab3000.Exam;
using Vocab3000.Provider;
using Vocab3000.Model;
using Vocab3000.UI;
using Vocab3000.Validator;

namespace Vocab3000.Builder
{
    public class ExamHandlerBuilder
    {
        private ExamHandler _hander;

        public ExamHandlerBuilder()
        {
            _hander = new ExamHandler();
        }

        public ExamHandler Build()
        {
            return _hander;
        }

        public ExamHandlerBuilder SetVocabProvider(IVocabDataProvider vocabProvider)
        {
            _hander.SetVocabProvider(vocabProvider);
            return this;
        }

        public ExamHandlerBuilder SetUserInterface(IUserInterface ui)
        {
            _hander.SetUserInterface(ui);
            return this;
        }

        public ExamHandlerBuilder SetResultCalculator(ExamResultCalculator resultCalculator)
        {
            _hander.SetResultCalculator(resultCalculator);
            return this;
        }

        public ExamHandlerBuilder SetAnswerValidator(IAnswerValidator answerValidator)
        {
            _hander.SetAnswerValidator(answerValidator);
            return this;
        }
    }
}