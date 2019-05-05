using System;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Memo.Api.Application.Command;
using Memo.Api.Application.CQRS;
using Memo.Core.CQRS;
using Memo.Infrastructure.UnitOfWork;

namespace Memo.Api.Application.CommandHandler
{
    public class UpdateWordCommandHandler : CommandHandler<UpdateWordCommand>
    {
        public UpdateWordCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<Result> Handle(UpdateWordCommand command)
        {
            try
            {
                var wordToUpdate = await UnitOfWork.WordRepository.GetWord(command.Id);

                await UnitOfWork.WordRepository.UpdateWord(wordToUpdate.First());
                return Result.Ok("Ok");
            }
            catch (Exception e)
            {
                return Result.Fail("Not Found");
            }
        }
    }
}