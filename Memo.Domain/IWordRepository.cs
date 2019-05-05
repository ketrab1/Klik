using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Memo.Core;
using Memo.Domain.WordAggregate;
using Memo.Domain.WordsModel;

namespace Memo.Domain
{
    public interface IWordRepository
    {
        Task<Option<Word>> GetWord(Guid id);
        Task<List<Word>> GetWords(int page, int numberPerPage);
        Task<List<Word>> GetWords(IEnumerable<Guid> ids);
        Task CreateWord(Word word);
        Task DeleteWord(Guid id);
        Task UpdateWord(Word word);
        Task SaveChanges();
    }
}
