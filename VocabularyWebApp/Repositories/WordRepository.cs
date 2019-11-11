using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppData;
using VocabularyWebApp.Models;

namespace VocabularyWebApp.Repositories
{
    public class WordRepository : IWordRepository
    {
        private VocabularyContext context = new VocabularyContext();

        public List<WordModel> GetAllWords()
        {
            return context.Words
                .Select(w => new WordModel { WordId = w.WordId, Word = w.Word, Definition = w.Definition, Etymology = w.Etymology })
                .ToList();
        }
        public WordModel GetOneWord(int WordId)
        {
            var entity = context.Words.Single(w => w.WordId == WordId);
            return new WordModel
            {
                WordId = entity.WordId,
                Word = entity.Word,
                Definition = entity.Definition,
                Etymology = entity.Etymology
            };
        }

        public void UpdateWord(WordModel model)
        {
            var entity = context.Words.Single(w => w.WordId == model.WordId);
            entity.Word = model.Word;
            entity.Definition = model.Definition;
            entity.Etymology = model.Etymology;
            context.SaveChanges();
        }

        public void AddWord(WordModel wordModel)
        {
            context.Words.Add(new Words { WordId = wordModel.WordId, Word = wordModel.Word, Definition = wordModel.Definition, Etymology = wordModel.Etymology });
            context.SaveChanges();
        }

        public void DeleteWord(int WordId)
        {
            var entity = context.Words.Single(w => w.WordId == WordId);
            context.Words.Remove(entity);
            context.SaveChanges();
        }
    }
}
