using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Memo.Core
{
    public interface IMediator
    {
        Task Publish<T>(T domainEvent) where T : IDomainEvent;
    }
}
