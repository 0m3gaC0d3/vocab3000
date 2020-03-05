using Vocab3000.Exam;
using Vocab3000.Factory;

namespace Vocab3000.UI
{
    public interface IUserInterface
    {
        void Start();

        ExamSettingsFactory.SettingTypes GetSettingsIndex();

        string GetUserInput(Iterator iterator);

        void HandleCurrent(Iterator iterator);

        void Quit(Calculator calculator);
    }
}