using System;
using System.IO;

namespace Vocab3000
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int test = 123;
            Console.WriteLine(ReadFromTextFile());
            Console.ReadKey();
        }

        public static int SomeMethod()
        {
            return 123;
        }

        private static string ReadFromTextFile()
        {

            StreamReader sr = new StreamReader("res/test.txt");

            String line = sr.ReadToEnd();

            return line;
        }
    }
}
