using Vocab3000.Exam;

namespace Vocab3000.UI
{
    public interface IUserInterface
    {
        void Start();

        int GetSettingsIndex();

        string GetUserInput(Iterator iterator);

        void HandleCurrent(Iterator iterator);

        void Quit(Calculator calculator);
    }
}