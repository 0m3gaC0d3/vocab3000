namespace Vocab3000.Exam.Settings
{
    public class FreeSettings : ISettings
    {
        public int GetVocabCount()
        {
            return ISettings.ALL_VOCABS;
        }

        public bool HelpIsAllowed()
        {
            return true;
        }
    }
}