using System;
using System.ComponentModel.DataAnnotations;
using Memo.Core.CQRS;
using Memo.Datacontract;

namespace Memo.Api.Application.Command
{
    public class UpdateWordCommand : ICommand
    {
        public Guid Id { get; }

        [Required]
        public string Value { get; set; }
        [Required]
        public string Translation { get; set; }
        [Required]
        public int DifficultyWord { get; set; }
        
        public UpdateWordCommand(WordDtoForCreate dto , Guid id)
        {
            Id = id;
            Value = dto.Value;
            Translation = dto.Translation;
            DifficultyWord = dto.DifficultyWord;
        }
    }
}