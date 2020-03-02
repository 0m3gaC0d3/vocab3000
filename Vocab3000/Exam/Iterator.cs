using System;
using System.Collections;
using System.Collections.Generic;
using Vocab3000.Model;
using Vocab3000.Exam.Settings;
using Vocab3000.Provider;

namespace Vocab3000.Exam
{
    public class Iterator : IEnumerator
    {

        private Vocab[] _vocabs;

        private int _position = -1;

        private ISettings _settings;

        public object Current => GetCurrent();

        public Iterator(ISettings settings, IVocabDataProvider provider)
        {
            _settings = settings;
            _vocabs = LoadVocabs(provider.GetVocabs());
        }

        private Vocab[] LoadVocabs(List<Vocab> allVocabs)
        {
            var vocabCountPerExam = _settings.GetVocabCount();
            if (vocabCountPerExam > allVocabs.Count)
            {
                throw new Exception("Vocabs for exam must be fewer or equal the overall vocab count");
            }
            var randomVocabs = new List<Vocab>();
            Random rnd = Vocab3000.Static.Random;
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
            return randomVocabs.ToArray();
        }

        public void SetVocabs(Vocab[] vocabs)
        {
            Reset();
            _vocabs = vocabs;
        }

        public Vocab[] GetVocabs()
        {
            return _vocabs;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _vocabs.Length);
        }

        public bool HasNext()
        {
            return ((1 + _position) < _vocabs.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        public int Count()
        {
            return _vocabs.Length;
        }

        public Vocab GetCurrent()
        {
            try
            {
                return _vocabs[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}