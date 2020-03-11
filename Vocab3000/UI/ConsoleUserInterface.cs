using System;
using System.Linq;
using Vocab3000.Exam;
using Vocab3000.Model;
using Vocab3000.Utility;
using Vocab3000.Factory;
using System.Text;

namespace Vocab3000.UI
{
    public class ConsoleUserInterface : IUserInterface
    {
        private int _usedHelp;

        public string GetUserInput(Iterator iterator)
        {
            var vocab = (Vocab)iterator.Current;
            var input = Console.ReadLine();
            while ("?" == input)
            {
                ++_usedHelp;
                Console.WriteLine("[HELP] (" + GenerateHelpString(vocab.Target) + ")");
                HandleCurrent(iterator);
                input = Console.ReadLine();
            }
            ConsoleUtility.WriteForgroundColoredLine("\t(" + vocab.Target + ")", ConsoleColor.Blue);
            return input;
        }

        public void Start()
        {
            Console.Clear();
            var banner = @"
\    / __   __   .    __   __   __   __   __ 
 \  / |  | |    /_\  |__)  __| |  | |  | |  |
  \/  |__| |__ /   \ |__)  __| |__| |__| |__| 
            ";
            Console.WriteLine("=============================================");
            Console.WriteLine(banner);
            Console.WriteLine("=============================================");
            Console.WriteLine("[Hint] Enter '?' if you need help");
            Console.WriteLine("---------------------------------------------");
        }

        public void Quit(Calculator calculator)
        {
            var result = Math.Round(calculator.GetCorrectAnswersInPercent());
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Exam is over (used help: {0})", GetUsedHelpAmount());
            Console.WriteLine("You result is: {0}%", calculator.GetCorrectAnswersInPercent());
            Console.WriteLine(
                "Right answers: {0} | Wrong answers: {1}",
                calculator.GetCorrectAnswerCount(),
                calculator.GetWrongAnswerCount()
            );
            Console.WriteLine("=============================================");
            Console.WriteLine("\n\nTo close the application hit any key...");
            Console.ReadKey();
        }

        public void HandleCurrent(Iterator iterator)
        {
            var vocab = (Vocab)iterator.Current;
            Console.Write("[");
            ConsoleUtility.WriteForgroundColored(vocab.Soruce, ConsoleColor.Yellow);
            Console.Write("] = ");
        }

        private string GenerateHelpString(string plainText)
        {
            var textLength = plainText.Length;
            var invisibleCharCount = (int)Math.Ceiling((float)textLength / 2);
            Random rnd = Vocab3000.Static.Random;
            StringBuilder strBuilder = new StringBuilder(plainText);
            foreach (var i in Enumerable.Range(0, invisibleCharCount))
            {
                var randomCahrIndex = rnd.Next(textLength - 1);
                strBuilder[randomCahrIndex] = '_';
            }
            return strBuilder.ToString();
        }

        public ExamSettingsFactory.SettingTypes GetSettingsIndex()
        {
            Console.WriteLine("Select exam type");
            Console.WriteLine("[1] Default (10 vocabs, unlimited help)");
            Console.WriteLine("[2] Test (30 vocabs, no help)");
            Console.WriteLine("[3] Free (All vocabs, unlimited help)");
            Console.Write("Please enter an option: ");
            return GetSettingTypeByUserInput(Console.ReadLine());
        }

        private ExamSettingsFactory.SettingTypes GetSettingTypeByUserInput(string input)
        {
            var type = ExamSettingsFactory.SettingTypes.Default;
            switch (input)
            {
                case "1":
                    type = ExamSettingsFactory.SettingTypes.Default;
                    break;
                case "2":
                    type = ExamSettingsFactory.SettingTypes.Test;
                    break;
                case "3":
                    type = ExamSettingsFactory.SettingTypes.Free;
                    break;
                default:
                    Console.WriteLine("---------------------------------------------");
                    ConsoleUtility.WriteForgroundColoredLine(
                        "Your input was invalid. Please only use one of the defined numbers.", ConsoleColor.DarkRed
                    );
                    return GetSettingsIndex();
            }
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            ConsoleUtility.WriteForgroundColoredLine("Exam starts now!", ConsoleColor.Yellow);
            Console.WriteLine("---------------------------------------------");
            return type;
        }

        public int GetUsedHelpAmount()
        {
            return _usedHelp;
        }
    }
}