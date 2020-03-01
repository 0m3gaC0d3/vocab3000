using System.Collections.Generic;
using Vocab3000.Model;

namespace Vocab3000.Provider
{
    public interface IVocabDataProvider
    {
        List<Vocab> GetVocabs();
    }
}