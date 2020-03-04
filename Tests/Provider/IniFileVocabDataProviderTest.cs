using NUnit.Framework;
using Vocab3000.Provider;
using IniParser.Model;
using System.Text;
using Moq;
using Vocab3000.Extension;

namespace Tests.Provider
{
    public class IniFileVocabDataProviderTest
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(-1, 0)]
        [TestCase(30, 30)]
        [TestCase(1000, 1000)]
        public void ReturnsRightAmountOfVocabs(int vocabAmount, int expected)
        {
            var testData = BuildTestIniDataWithXVocabs(vocabAmount);
            var parserMock = new Mock<IFileIniDataParser>();
            parserMock
                .Setup(parser => parser.ReadFile("res/vocabs.ini", Encoding.UTF8))
                .Returns(testData);
            var provider = new IniFileVocabDataProvider(parserMock.Object);
            var vocabs = provider.GetVocabs();
            Assert.AreEqual(expected, vocabs.Count);
        }

        private IniData BuildTestIniDataWithXVocabs(int vocabAmount)
        {
            var data = new IniData();
            var section = new SectionData("UnitTest");
            for(int i =0; i < vocabAmount;++i) {
                var vocab = new KeyData("Unit"+i);
                vocab.Value = "Einheit"+i;
                section.Keys.AddKey(vocab);
            }
            data.Sections.Add(section);
            return data;
        }
    }
}