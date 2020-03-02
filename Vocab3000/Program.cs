using Vocab3000.Provider;
using Vocab3000.UI;
using Vocab3000.Exam;
using Vocab3000.Validator;
using Vocab3000.Builder;

namespace Vocab3000
{
    public class Program
    {
        static void Main(string[] args)
        {
            var vocabCountPerExam = 10; // TODO: Get this by user input
            var handlerBuilder = new ExamHandlerBuilder();
            handlerBuilder.SetAnswerValidator(new StrictAnswerValidator())
                .SetResultCalculator(new ExamResultCalculator(vocabCountPerExam))
                .SetUserInterface(new ConsoleUserInterface())
                .SetVocabProvider(new IniFileVocabDataProvider())
                .Build()
                .Run();
        }
    }
}
