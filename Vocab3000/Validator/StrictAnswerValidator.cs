using Vocab3000.Model;

namespace Vocab3000.Validator
{
    public class StrictAnswerValidator : IAnswerValidator
    {
        public bool Validate(Vocab vocab, string userinput)
        {
            return vocab.Target == userinput;
        }
    }
}