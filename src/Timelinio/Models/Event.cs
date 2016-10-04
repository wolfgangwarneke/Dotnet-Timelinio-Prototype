using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timelinio.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public int TimelineID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Timeline Timeline { get; set; }

        //public int UserID { get; set; }
        //public ApplicationUser User { get; set; }
    }
}
