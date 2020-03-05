namespace Vocab3000.Exam.Settings
{
    public interface ISettings
    {
        const int ALL_VOCABS = -1;

        int GetVocabCount();

        bool HelpIsAllowed();
    }
}