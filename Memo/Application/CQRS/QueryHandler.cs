using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Memo.Core.CQRS;
using Memo.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Memo.Api.Application.CQRS
{
    public abstract class QueryHandler<TQuery,TResult> : IQueryHandler<TQuery,TResult> where TQuery :  IQuery<TResult> 
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected QueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public abstract Task<TResult> Execute(TQuery query);

    }
}