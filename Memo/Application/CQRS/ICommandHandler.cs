using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Memo.Core.CQRS;
using Memo.Infrastructure.UnitOfWork;

namespace Memo.Api.Application.CQRS
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task<Result> Handle(T command);
    }

    public abstract class CommandHandler<T> : ICommandHandler<T> where T : ICommand
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected CommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public abstract Task<Result> Handle(T command);
    }
}
