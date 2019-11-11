using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VocabularyAppData
{
    public partial class Words
    {
        [Key]
        [Column("WordID")]
        public int WordId { get; set; }
        [StringLength(15)]
        public string Word { get; set; }
        [StringLength(150)]
        public string Definition { get; set; }
        [StringLength(150)]
        public string Etymology { get; set; }
    }
}