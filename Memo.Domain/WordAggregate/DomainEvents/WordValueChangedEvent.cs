using System;
using Memo.Core;

namespace Memo.Domain.WordAggregate.DomainEvents
{
    public class WordValueChangedEvent : IDomainEvent
    {
        public Guid Id { get; }

        public WordValueChangedEvent(Guid id)
        {
            Id = id;
        }
    }
}