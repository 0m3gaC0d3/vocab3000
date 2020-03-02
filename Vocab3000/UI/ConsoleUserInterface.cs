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
        public string GetUserInput(Vocab vocab)
        {
            var input = Console.ReadLine();
            while("?" == input) {
                Console.WriteLine("[HELP] ("+GenerateHelpString(vocab.Target)+")");
                HandleCurrentVocab(vocab);
                input = Console.ReadLine();
            }
            ConsoleUtility.WriteForgroundColoredLine("\t("+vocab.Target+")", ConsoleColor.Blue);
            return input;
        }

        public void Initialize(ExamResultCalculator resultCalculator)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Welcome to Vocab3000");
            Console.WriteLine("");
            Console.WriteLine("Starting a new exam with "+resultCalculator.GetVocabCount().ToString()+" vocabs.");
            Console.WriteLine("[Hint] Enter '?' if you need help");
            Console.WriteLine("--------------------------");
        }

        public void Quit(ExamResultCalculator resultCalculator)
        {
            var result = Math.Round(resultCalculator.GetCorrectAnswersInPercent());
            Console.WriteLine("--------------------------");
            Console.WriteLine("Exam is over");
            Console.WriteLine("You result is: "+result.ToString()+"%");
            Console.WriteLine("==========================");
        }

        public void HandleCurrentVocab(Vocab vocab)
        {
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

    }
}