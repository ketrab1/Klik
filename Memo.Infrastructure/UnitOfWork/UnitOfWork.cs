using Memo.Domain;
using Memo.Infrastructure.Repository;

namespace Memo.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }


        public IWordRepository WordRepository => new WordRepository(_context);
    }
}