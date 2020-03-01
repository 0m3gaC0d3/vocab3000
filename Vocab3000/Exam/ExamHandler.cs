using System;
using System.Collections.Generic;
using Vocab3000.Provider;
using Vocab3000.Model;
using Vocab3000.UI;
using Vocab3000.Validator;

namespace Vocab3000.Exam
{
    public class ExamHandler
    {
        private IVocabDataProvider _vocabProvider;

        private IUserInterface _ui;

        private ExamResultCalculator _resultCalculator;

        private IAnswerValidator _answerValidator;

        public void Run()
        {
            _ui.Initialize();
            var vocabs = RandomizeAndTrimVocabs();
            foreach (Vocab vocab in vocabs)
            {
                HandleCurrentVocab(vocab);
            }
            _ui.Quit(_resultCalculator);
        }

        private List<Vocab> RandomizeAndTrimVocabs()
        {
            var allVocabs = _vocabProvider.GetVocabs();
            var vocabCountPerExam = _resultCalculator.GetVocabCount();
            if (vocabCountPerExam > allVocabs.Count)
            {
                throw new Exception("Vocabs for exam must be fewer or equal the overall vocab count");
            }
            var randomVocabs = new List<Vocab>();
            Random rnd = new Random();
            for (int i = 0; i < vocabCountPerExam; ++i)
            {
                int randomIndex = rnd.Next(allVocabs.Count);
                var vocabToAdd = allVocabs[randomIndex];
                while (randomVocabs.Contains(vocabToAdd))
                {
                    randomIndex = rnd.Next(allVocabs.Count);
                    vocabToAdd = allVocabs[randomIndex];
                }
                randomVocabs.Add(vocabToAdd);
            }
            return randomVocabs;
        }

        private void HandleCurrentVocab(Vocab vocab)
        {
            _ui.HandleCurrentVocab(vocab);
            if (_answerValidator.Validate(vocab, _ui.GetUserInput()))
            {
                _resultCalculator.increaseCorrectAnswersByOne();
            }
            else
            {
                _resultCalculator.increaseWrongAnswersByOne();
            }
        }

        public void SetVocabProvider(IVocabDataProvider vocabProvider)
        {
            _vocabProvider = vocabProvider;
        }

        public void SetUserInterface(IUserInterface ui)
        {
            _ui = ui;
        }

        public void SetResultCalculator(ExamResultCalculator resultCalculator)
        {
            _resultCalculator = resultCalculator;
        }

        public void SetAnswerValidator(IAnswerValidator answerValidator)
        {
            _answerValidator = answerValidator;
        }
    }
}