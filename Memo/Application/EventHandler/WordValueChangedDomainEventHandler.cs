using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Memo.Core;
using Memo.Domain.WordAggregate.DomainEvents;
using Memo.Infrastructure.UnitOfWork;

namespace Memo.Api.Application.EventHandler
{
    public class WordValueChangedDomainEventHandler : IEventHandler<WordValueChangedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public WordValueChangedDomainEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(WordValueChangedEvent domainEvent)
        {
            var entity = await _unitOfWork.WordRepository.GetWord(domainEvent.Id);
            entity.ForEach(x => x.WordStatistic.ClearStatistics());  
            
            await _unitOfWork.WordRepository.SaveChanges();
        }
    }
    

}