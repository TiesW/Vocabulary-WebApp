using System.Collections.Generic;
using VocabularyWebApp.Models;

namespace VocabularyWebApp.Repositories
{
    public interface IWordRepository
    {
        List<WordModel> GetAllWords();
        WordModel GetOneWord(int WordId);
        void AddWord(WordModel wordModel);
        void UpdateWord(WordModel wordModel);
        void DeleteWord(int WordId);
    }
}