using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timelinio.Models
{
    [Table("Focuses")]
    public class Focus
    {
        [Key]
        public int FocusID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Timeline> Timelines { get; set; }

        //public Focus() { }
    }
}