using Vocab3000.Validator;
using Vocab3000.Model;
using NUnit.Framework;

namespace Tests.Validator
{
    public class StrictAnswerValidatorTest
    {
        [Test]
        public void ValidatesToTrue()
        {
            var input = "Einheit";
            var vocab = new Vocab { Soruce = "Unit", Target = "Einheit" };
            var validator = new StrictAnswerValidator();
            var result = validator.Validate(vocab, input);
            Assert.True(result);
        }

        [Test]
        public void ValidatesToFalse()
        {
            var vocab = new Vocab { Soruce = "Unit", Target = "Einheit" };
            var validator = new StrictAnswerValidator();
            var result = validator.Validate(vocab, "FALSE");
            Assert.False(result);
        }

        [Test]
        public void CanHandleUTF8()
        {
            var input = "öüä";
            var vocab = new Vocab { Soruce = "Unit", Target = input };
            var validator = new StrictAnswerValidator();
            var result = validator.Validate(vocab, input);
            Assert.True(result);
        }

        [Test]
        public void CanHandleSpacesAndSpecialChars()
        {
            var input = "/ _!#-$%&/{=";
            var vocab = new Vocab { Soruce = "Unit", Target = input };
            var validator = new StrictAnswerValidator();
            var result = validator.Validate(vocab, input);
            Assert.True(result);
        }

        [Test]
        public void IsCaseSensetive()
        {
            var input = "ABC";
            var vocab = new Vocab { Soruce = "Unit", Target = input };
            var validator = new StrictAnswerValidator();
            var result = validator.Validate(vocab, input.ToLower());
            Assert.False(result);
        }
    }
}