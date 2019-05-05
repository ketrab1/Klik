using Memo.Domain;

namespace Memo.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IWordRepository WordRepository { get; }
    }
}