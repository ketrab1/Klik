using System;
using FluentValidation;
using Memo.Core;
using Memo.Datacontract;
using Memo.Domain.WordAggregate.DomainEvents;
using Memo.Domain.WordsModel;
using static System.String;

namespace Memo.Domain.WordAggregate
{
    public class Word : Entity
    {
        protected Word() { }
        public Word(string value, string translation, DifficultyWord difficultyWord)
        {
            if(IsNullOrWhiteSpace(value))
                throw new ArgumentException("value");
            if (IsNullOrWhiteSpace(translation))
                throw new ArgumentException("translation");

            Id = Guid.NewGuid();
            Value = value;
            CreateDate = DateTime.Now;
            Translation = translation;
            SetDifficulty(difficultyWord);
            WordStatistic = new WordStatistic();

        }
        public string Value { get; private set; }
        public string Translation { get; private set; }
        public virtual DateTime CreateDate { get; private set; }
        public WordStatistic WordStatistic { get; private set; }

        public DateTime NextIteration { get; private set; }
        
        public virtual DifficultyWord DifficultyWord { get; private set; }

        public void SetDifficulty(DifficultyWord difficultyWord)
        {
            DifficultyWord = difficultyWord;
            AddDomainEvent(new WordDifficultyChangedEvent(DifficultyWord));
        }

        public void ChangeValue(string newValue, string translation)
        {
            if (IsNullOrWhiteSpace(newValue))
                throw new ArgumentNullException(nameof(newValue));
            if (IsNullOrWhiteSpace(translation))
                throw new ArgumentException( nameof(translation));

            Value = newValue;
            Translation = translation;
            
            AddDomainEvent(new WordValueChangedEvent(Id));
        }

        public void SetNextIteration(DateTime date)
        {
            NextIteration = date;
        }
        
    }

    public static class WordExtensions
    {
        public static bool IsValid(this Word word, WordDtoValid secondWord)
        {
            return word.Id == secondWord.Id && word.Translation == secondWord.YourTranslation;
        }
    }

    public class WordValidator : AbstractValidator<Word>
    {
        public WordValidator()
        {
            RuleFor(x => x.Value).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Translation).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.WordStatistic).NotNull();
        }
    }

  
}
