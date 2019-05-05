using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memo.Core;
using Memo.Domain;
using Memo.Domain.WordAggregate;
using Memo.Domain.WordsModel;
using Microsoft.EntityFrameworkCore;

namespace Memo.Infrastructure.Repository
{
    public class WordRepository : IWordRepository
    {
        private readonly Context _context;

        public WordRepository(Context context)
        {
            _context = context;
        }

        public async Task<Option<Word>> GetWord(Guid id)
        {
            var result = await _context.Words.FirstOrDefaultAsync(x => x.Id == id);
            return result != null ? Option<Word>.Create(result) : Option<Word>.CreateEmpty();
        }

        public async Task<List<Word>> GetWords(int page, int numberPerPage)
        {
            return await _context.Words
                .Include(x => x.WordStatistic)
                .Take(numberPerPage)
                .Skip(numberPerPage * (page - 1))
                .ToListAsync();
        }

        public async Task<List<Word>> GetWords(IEnumerable<Guid> ids)
        {
            return await _context.Words.Include(x => x.WordStatistic).Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task CreateWord(Word word)
        {
           await _context.Words.AddAsync(word);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteWord(Guid id)
        {
            var toRemove = await _context.Words.FindAsync(id);
            _context.Words.Remove(toRemove);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWord(Word word)
        {
            _context.Words.Update(word);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
           await _context.SaveChangesAsync();
        }
    }

}
