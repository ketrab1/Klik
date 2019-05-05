using System.Collections.Generic;
using Memo.Core.CQRS;
using Memo.Domain.WordAggregate;

namespace Memo.Api.Application.Query
{
    public class PagedWordQuery : IQuery<List<Word>>
    {
        public int Page { get; }
        public int NumberPerPage { get; }

        public PagedWordQuery(int page, int numberPerPage)
        {
            Page = page;
            NumberPerPage = numberPerPage;
        }
    }
}