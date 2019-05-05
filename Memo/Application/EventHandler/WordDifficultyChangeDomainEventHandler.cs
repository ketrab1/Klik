using System.Threading.Tasks;
using Memo.Core;
using Memo.Domain.WordAggregate.DomainEvents;

namespace Memo.Api.Application.EventHandler
{
    public class WordDifficultyChangeDomainEventHandler : IEventHandler<WordDifficultyChangedEvent>
    {
        public Task Handle(WordDifficultyChangedEvent domainEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}