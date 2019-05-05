using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core.Lifetime;
using CSharpFunctionalExtensions;
using Memo.Api.Application.CQRS;
using Memo.Core.CQRS;

namespace Memo.Api.Application
{
    public class Dispatcher : IDispatcher
    {
        private readonly ILifetimeScope _lifetimeScope;

        public Dispatcher(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public async Task<Result> DispatchCommand<T>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var handler = _lifetimeScope.Resolve<CommandHandler<T>>(); 
            return await handler.Handle((T)command);
        }

        public async Task<TResult> DispatchQuery<T, TResult>(T query) where T : IQuery<TResult>
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var handler = _lifetimeScope.Resolve<QueryHandler<T,TResult>>(); 
            return await handler.Execute(query);
        }
    }

    public interface IDispatcher
    {
        Task<Result> DispatchCommand<T>(T command) where T : ICommand;
        Task<TResult> DispatchQuery<T, TResult>(T query) where T : IQuery<TResult>;
    }
}
