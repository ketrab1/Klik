using Autofac;
using Memo.Api.Application;
using Memo.Api.Application.CQRS;
using Memo.Core;
using Memo.Core.CQRS;
using Memo.Domain;
using Memo.Infrastructure.Repository;
using Memo.Infrastructure.UnitOfWork;

namespace Memo.Api.Module
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsClosedTypesOf(typeof(IEventHandler<>));
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsClosedTypesOf(typeof(CommandHandler<>));
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsClosedTypesOf(typeof(QueryHandler<,>));
            
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.RegisterType<Dispatcher>().As<IDispatcher>().InstancePerLifetimeScope();
          
        }
    }

    public class AutoFacRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
        }
    }
}