using System.Text;
using IniParser.Model;
using IniParser;

namespace Vocab3000.Extension
{
    public class FileIniDataParserExtension : IFileIniDataParser
    {
        private FileIniDataParser _parser;

        public FileIniDataParserExtension(FileIniDataParser parser)
        {
            _parser = parser;
        }

        public IniData ReadFile(string relativeFilePath, Encoding encoding)
        {
            return _parser.ReadFile(relativeFilePath, encoding);
        }
    }
}