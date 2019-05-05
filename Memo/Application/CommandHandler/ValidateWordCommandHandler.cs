using System;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Memo.Api.Application.Command;
using Memo.Api.Application.CQRS;
using Memo.Core.CQRS;
using Memo.Domain;
using Memo.Domain.WordAggregate;
using Memo.Infrastructure.UnitOfWork;

namespace Memo.Api.Application.CommandHandler
{
    public class ValidateWordCommandHandler : ICommandHandler<ValidateWordCommand>
    {
        private readonly IUnitOfWork _repository;

        public ValidateWordCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }
        public async Task<Result> Handle(ValidateWordCommand command)
        {
            try
            {
                if (command == null) throw new ArgumentNullException(nameof(command));
                
                var ids = command.ListWordToValid.Select(x => x.Id).ToList();
    
                var wordsToValid = await _repository.WordRepository.GetWords(ids);
    
                foreach (var word in wordsToValid)
                {
                    var wordToValid = command.ListWordToValid.FirstOrDefault(x => x.Id == word.Id);
    
                    if (word.IsValid(wordToValid))
                    {
                        word.WordStatistic.IncrementNumberTypedCorrect();
                    }
                    else
                    {
                        word.WordStatistic.IncrementTypedWrong();
                    }
                }
                await _repository.WordRepository.SaveChanges();
                return Result.Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Result.Fail(e.Message);
            }
          
        }
    }
}