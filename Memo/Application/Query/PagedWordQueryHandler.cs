using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Memo.Api.Application.CQRS;
using Memo.Core.CQRS;
using Memo.Domain.WordAggregate;
using Memo.Infrastructure.UnitOfWork;

namespace Memo.Api.Application.Query
{
    public class PagedWordQueryHandler : QueryHandler<PagedWordQuery, List<Word>>
    {
        public PagedWordQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<List<Word>> Execute(PagedWordQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            return await _unitOfWork.WordRepository.GetWords(query.Page, query.NumberPerPage);
        }
    }
}