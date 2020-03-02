using Vocab3000.Provider;
using Vocab3000.UI;
using Vocab3000.Exam;
using Vocab3000.Validator;
using Vocab3000.Factory;

namespace Vocab3000
{
    public class Program
    {
        static void Main(string[] args)
        {
            var validator = new StrictAnswerValidator();
            var vocabProvider = new IniFileVocabDataProvider();
            var ui = new ConsoleUserInterface();
            ui.Start();
            var settingsIndex = ui.GetSettingsIndex();
            var settings = ExamSettingsFactory.Build((ExamSettingsFactory.SettingTypes)settingsIndex);
            var calculator = new Calculator(settings.GetVocabCount());
            var iterator = new Iterator(settings, vocabProvider);
            var handler = new Handler(ui, settings, iterator, calculator, validator);
            handler.Run();
            ui.Quit(calculator);
        }
    }
}
