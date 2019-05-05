using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Memo.Core;
using Memo.Infrastructure.Repository;

namespace Memo.Api.Application
{
    public class Mediator : IMediator
    {
        private readonly IComponentContext _scope;

        public Mediator(ILifetimeScope scope)
        {
            _scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }

        public async Task Publish<T>(T domainEvent) where T : IDomainEvent
        {
            if (domainEvent == null) throw new ArgumentNullException(nameof(domainEvent));

            var eventHandlers = this._scope.Resolve<IEnumerable<IEventHandler<T>>>().ToList();

            foreach (var task in eventHandlers)
            {
                await task.Handle(domainEvent);
            }
        }
    }
}