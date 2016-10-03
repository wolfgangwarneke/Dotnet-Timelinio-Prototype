using System;
using System.Collections.Generic;

namespace Timelinio.Models
{
    public class Timeline
    {

        public int TimelineID { get; set; }
        public int FocusID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public Focus Focus { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
