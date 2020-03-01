using Vocab3000.Model;

namespace Vocab3000.Validator
{
    public interface IAnswerValidator
    {
         bool Validate(Vocab vocab, string userinput);
    }
}