using IniParser.Model;
using System.Text;

namespace Vocab3000.Extension
{
    public interface IFileIniDataParser
    {
        IniData ReadFile(string relativeFilePath, Encoding encoding);
    }
}