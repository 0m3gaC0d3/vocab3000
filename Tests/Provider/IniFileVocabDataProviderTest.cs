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
        [Test]
        public void ReturnsRightAmountOfVocabs()
        {
            var testData = BuildTestIniData();
            var parserMock = new Mock<IFileIniDataParser>();
            parserMock
                .Setup(parser => parser.ReadFile("res/vocabs.ini", Encoding.UTF8))
                .Returns(testData);
            var provider = new IniFileVocabDataProvider(parserMock.Object);
            var vocabs = provider.GetVocabs();
            Assert.AreEqual(2, vocabs.Count);
        }

        //... more tests!

        private IniData BuildTestIniData()
        {
            var data = new IniData();
            var section = new SectionData("UnitTest");
            var vocabA = new KeyData("Unit");
            vocabA.Value = "Einheit";
            var vocabB = new KeyData("Vocab");
            vocabA.Value = "Vokabel";
            section.Keys.AddKey(vocabA);
            section.Keys.AddKey(vocabB);
            data.Sections.Add(section);
            return data;
        }
    }
}