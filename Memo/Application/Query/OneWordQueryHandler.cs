using System;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Memo.Api.Application.CQRS;
using Memo.Core.CQRS;
using Memo.Domain.WordAggregate;
using Memo.Infrastructure.UnitOfWork;

namespace Memo.Api.Application.Query
{
    public class OneWordQueryHandler : QueryHandler<OneWordQuery, Word>
    {

        public OneWordQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public override async Task<Word> Execute(OneWordQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            
            var result = await _unitOfWork.WordRepository.GetWord(query.Id);
            return result.First();
        }
    }
}