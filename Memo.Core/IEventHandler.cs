using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Memo.Core
{
    public interface IEventHandler<T> where T : IDomainEvent
    {
        Task Handle(T domainEvent);
    }
}
