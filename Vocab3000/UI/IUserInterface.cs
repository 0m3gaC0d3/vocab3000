using Vocab3000.Model;
using Vocab3000.Exam;

namespace Vocab3000.UI
{
    public interface IUserInterface
    {
        void Initialize(ExamResultCalculator resultCalculator);

        string GetUserInput(Vocab vocab);

        void HandleCurrentVocab(Vocab vocab);

        void Quit(ExamResultCalculator resultCalculator);
    }
}