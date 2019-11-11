using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VocabularyWebApp.Models
{
    public class WordModel
    {
        public int WordId { get; set; }
        [Required (ErrorMessage = "The 'Word' field is required")]
        [StringLength(15)]
        public string Word { get; set; }
        [Required(ErrorMessage = "The 'Definition' field is required")]
        [StringLength(150)]
        public string Definition { get; set; }
        [Required(ErrorMessage = "The 'Etymology' field is required")]
        [StringLength(150)]
        public string Etymology { get; set; }
    }
}
