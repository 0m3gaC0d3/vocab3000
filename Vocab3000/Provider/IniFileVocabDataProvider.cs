using System.Collections.Generic;
using System.Text;
using Vocab3000.Model;
using IniParser;
using IniParser.Model;
using Vocab3000.Extension;

namespace Vocab3000.Provider
{
    public class IniFileVocabDataProvider : IVocabDataProvider
    {
        private const string RelativeFilePath = "res/vocabs.ini";

        private IFileIniDataParser _parser;

        public IniFileVocabDataProvider(IFileIniDataParser parser)
        {
            _parser = parser;
        }

        public List<Vocab> GetVocabs()
        {
            var iniData = ReadFromIniFile();
            return TranslateIniDataToVocabList(iniData);
        }

        private List<Vocab> TranslateIniDataToVocabList(IniData iniData)
        {
            var vocabs = new List<Vocab>();
            // Currently there is no speration between sections.
            foreach (SectionData section in iniData.Sections)
            {
                foreach (KeyData key in section.Keys)
                {
                    var vocab = new Vocab();
                    vocab.Soruce = key.KeyName;
                    vocab.Target = key.Value;
                    vocabs.Add(vocab);
                }
            }
            return vocabs;
        }

        private IniData ReadFromIniFile()
        {
            IniData data = _parser.ReadFile(RelativeFilePath, Encoding.UTF8);
            return data;
        }
    }
}