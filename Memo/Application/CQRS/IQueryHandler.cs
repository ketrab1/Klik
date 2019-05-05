using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Memo.Core.CQRS
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Execute(TQuery query);
    }
}
