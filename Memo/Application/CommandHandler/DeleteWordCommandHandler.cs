using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Memo.Api.Application.Command;
using Memo.Api.Application.CQRS;
using Memo.Infrastructure.UnitOfWork;

namespace Memo.Api.Application.CommandHandler
{
    public class DeleteWordCommandHandler : CommandHandler<DeleteWordCommand>
    {
        public DeleteWordCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<Result> Handle(DeleteWordCommand command)
        {
            try
            {
                await UnitOfWork.WordRepository.DeleteWord(command.Id);
                return Result.Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Result.Fail("Fail");
            }

        }
    }
}