using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Memo.Api.Application.Command;
using Memo.Api.Application.CQRS;
using Memo.Core.CQRS;
using Memo.Domain;
using Memo.Domain.WordAggregate;
using Memo.Domain.WordsModel;
using Memo.Infrastructure.UnitOfWork;

namespace Memo.Api.Application.CommandHandler
{
    public class CreateWordCommandHandler : ICommandHandler<CreateWordCommand>
    {
        private readonly IUnitOfWork _repository;

        public CreateWordCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(CreateWordCommand command)
        {
            try
            {
                if (command == null) throw new ArgumentNullException(nameof(command));
    
                var newWord = new Word(command.Value, command.Translation, (DifficultyWord) command.DifficultyWord);
    
                await _repository.WordRepository.CreateWord(newWord);
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
