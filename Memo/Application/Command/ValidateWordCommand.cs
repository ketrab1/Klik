using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Memo.Core.CQRS;
using Memo.Datacontract;

namespace Memo.Api.Application.Command
{
    public class ValidateWordCommand : ICommand
    {
        public List<WordDtoValid> ListWordToValid { get; }


        public ValidateWordCommand(List<WordDtoValid> dto)
        {
            ListWordToValid = dto;
        }
    }

}