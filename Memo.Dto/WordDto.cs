using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Memo.Datacontract
{
    public class WordDtoForCreate
    {
        [Required]
        public string Value { get; set; }
        [Required]
        public string Translation { get; set; }
        [Required]
        public int DifficultyWord { get; set; }
    }
    public class WordDtoSend
    {    
        [Required]
        public string Value { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Translation { get; set; }
        [Required]
        public int DifficultyWord { get; set; }
        
        public int NumberTypedCorrect { get; set; }
        public int TimesTypedWrong { get; set; }
        public int TimesLoaded { get; set; }
 
    }

    public class WordDtoValid
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string YourTranslation { get; set; }
        [Required]
        public int DifficultyWord { get; set; }
        
        public int NumberTypedCorrect { get; set; }
        public int TimesTypedWrong { get; set; }
        public int TimesLoaded { get; set; }
    }

}
