using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Memo.Core.CQRS;
using Memo.Domain.WordAggregate;

namespace Memo.Api.Application.Query
{
    public class OneWordQuery : IQuery<Word>
    {
        public Guid Id { get; }

        public OneWordQuery(Guid id)
        {
            Id = id;
        }
    }
}