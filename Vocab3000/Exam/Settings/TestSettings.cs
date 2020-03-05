namespace Vocab3000.Exam.Settings
{
    public class TestSettings : ISettings
    {
        public int GetVocabCount()
        {
            return 30;
        }

        public bool HelpIsAllowed()
        {
            return false;
        }
    }
}