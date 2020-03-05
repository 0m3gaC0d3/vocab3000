using Vocab3000.Provider;
using Vocab3000.UI;
using Vocab3000.Exam;
using Vocab3000.Validator;
using Vocab3000.Factory;
using IniParser;
using Vocab3000.Extension;

namespace Vocab3000
{
    public class Program
    {
        static void Main(string[] args)
        {
            var validator = new StrictAnswerValidator();
            var parser = new FileIniDataParserExtension(new FileIniDataParser());
            var vocabProvider = new IniFileVocabDataProvider(parser);
            var ui = new ConsoleUserInterface();
            ui.Start();
            var settingsIndex = ui.GetSettingsIndex();
            var settings = ExamSettingsFactory.Build((ExamSettingsFactory.SettingTypes)settingsIndex);
            var iterator = new Iterator(settings, vocabProvider);
            var calculator = new Calculator(iterator.Count());
            var handler = new Handler(ui, settings, iterator, calculator, validator);
            handler.Run();
            ui.Quit(calculator);
        }
    }
}
