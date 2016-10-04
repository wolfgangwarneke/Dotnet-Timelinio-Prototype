using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timelinio.Models
{
    [Table("Timelines")]
    public class Timeline
    {
        [Key]
        public int TimelineID { get; set; }
        //public int UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int FocusID { get; set; }
        public Focus Focus { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        
        public ICollection<Event> Events { get; set; }

        
    }
}