using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Memo.Core.CQRS;
using Memo.Datacontract;

namespace Memo.Api.Application.Command
{
    public class CreateWordCommand : ICommand
    {
        public CreateWordCommand(WordDtoForCreate wordDtoForCreate)
        {
            Value = wordDtoForCreate.Value;
            Translation = wordDtoForCreate.Translation;
            DifficultyWord = wordDtoForCreate.DifficultyWord;
        }

        public CreateWordCommand()
        {
            
        }

        [Required]
        public string Value { get; set; }
        [Required]
        public string Translation { get; set; }
        [Required]
        public int DifficultyWord { get; set; }
    }
}
