using Memo.Core;
using Memo.Domain.WordsModel;

namespace Memo.Domain.WordAggregate.DomainEvents
{
    public class WordDifficultyChangedEvent : IDomainEvent
    {
        public DifficultyWord DifficultyWord { get; }

        public WordDifficultyChangedEvent(DifficultyWord difficultyWord)
        {
            DifficultyWord = difficultyWord;
        }
    }
}