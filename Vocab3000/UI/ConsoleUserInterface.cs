using System;
using System.Linq;
using Vocab3000.Exam;
using Vocab3000.Model;
using Vocab3000.Utility;
using System.Text;

namespace Vocab3000.UI
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string GetUserInput(Iterator iterator)
        {
            var vocab = (Vocab) iterator.Current;
            var input = Console.ReadLine();
            while("?" == input) {
                Console.WriteLine("[HELP] ("+GenerateHelpString(vocab.Target)+")");
                HandleCurrent(iterator);
                input = Console.ReadLine();
            }
            ConsoleUtility.WriteForgroundColoredLine("\t("+vocab.Target+")", ConsoleColor.Blue);
            return input;
        }

        public void Start()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Welcome to Vocab3000");
            Console.WriteLine("");
            Console.WriteLine("[Hint] Enter '?' if you need help");
            Console.WriteLine("--------------------------");
        }

        public void Quit(Calculator calculator)
        {
            var result = Math.Round(calculator.GetCorrectAnswersInPercent());
            Console.WriteLine("--------------------------");
            Console.WriteLine("Exam is over");
            Console.WriteLine("You result is: "+result.ToString()+"%");
            Console.WriteLine("==========================");
            Console.WriteLine("\n\nTo close the application hit any key...");
            Console.ReadKey();
        }

        public void HandleCurrent(Iterator iterator)
        {
            var vocab = (Vocab) iterator.Current;
            Console.Write("[");
            ConsoleUtility.WriteForgroundColored(vocab.Soruce, ConsoleColor.Yellow);
            Console.Write("] = ");
        }

        private string GenerateHelpString(string plainText)
        {
            var textLength = plainText.Length;
            var invisibleCharCount = (int) Math.Ceiling((float) textLength / 2);
            Random rnd = Vocab3000.Static.Random;
            StringBuilder strBuilder = new StringBuilder(plainText);
            foreach (var i in Enumerable.Range(0, invisibleCharCount))
            {
                var randomCahrIndex = rnd.Next(textLength -1);
                strBuilder[randomCahrIndex] = '_';
            }
            return strBuilder.ToString();
        }

        public int GetSettingsIndex()
        {
            // TODO change me
            return 1;
        }
    }
}