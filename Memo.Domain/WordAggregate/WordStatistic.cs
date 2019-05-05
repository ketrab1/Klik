using System;
using System.Collections.Generic;
using System.Text;
using Memo.Core;
using Memo.Domain.WordAggregate;

namespace Memo.Domain.WordsModel
{
    public class WordStatistic : Entity
    {
        public WordStatistic()
        {
        }
        public virtual int NumberTypedCorrect { get; private set; }

        public virtual int TimesTypedWrong { get; private set; }

        public virtual int TimesLoaded { get; private set; }

        public void IncrementTimeLoaded()
        {
            TimesLoaded++;
        }
        public void IncrementTypedWrong()
        {
            TimesTypedWrong++;
        }
        public void IncrementNumberTypedCorrect()
        {
            NumberTypedCorrect++;
        }

        public void ClearStatistics()
        {
            NumberTypedCorrect = default(int);
            TimesTypedWrong = default(int);
            TimesLoaded = default(int);
        }
        public virtual Word Word { get; set; }
        public virtual Guid WordId { get; set; }

    }
}
