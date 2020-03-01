using System;
using Vocab3000.Exam;
using Vocab3000.Model;

namespace Vocab3000.UI
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string GetUserInput()
        {
            var input = Console.ReadLine();

            return input;
        }

        public void Initialize()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Welcome to Vocab3000");
            Console.WriteLine("");
            Console.WriteLine("Starting a new exam!");
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
            Console.WriteLine("["+vocab.Soruce+"]");
        }
    }
}