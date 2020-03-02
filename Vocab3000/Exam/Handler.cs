using System;
using System.Collections.Generic;
using Vocab3000.Model;
using Vocab3000.Exam.Settings;
using Vocab3000.UI;
using Vocab3000.Validator;

namespace Vocab3000.Exam
{
    public class Handler
    {
        private IUserInterface _ui;

        private ISettings _settings;

        private Iterator _iterator;

        private Calculator _calculator;

        private IAnswerValidator _validator;

        public Handler(IUserInterface ui, ISettings settings, Iterator iterator, Calculator calculator, StrictAnswerValidator validator)
        {
            _ui = ui;
            _settings = settings;
            _iterator = iterator;
            _calculator = calculator;
            _validator = validator;
        }

        public void Run()
        {
            while(_iterator.HasNext()) {
                _iterator.MoveNext();
                var vocab = (Vocab) _iterator.Current;
                HandleCurrent(vocab);
            }
        }

        private void HandleCurrent(Vocab vocab)
        {
            _ui.HandleCurrent(_iterator);
            if (_validator.Validate(vocab, _ui.GetUserInput(_iterator)))
            {
                _calculator.increaseCorrectAnswersByOne();
            }
            else
            {
                _calculator.increaseWrongAnswersByOne();
            }
        }
    }
}