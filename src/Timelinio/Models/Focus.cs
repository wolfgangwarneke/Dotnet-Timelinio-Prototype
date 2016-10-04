using System;
using System.Collections.Generic;

namespace Timelinio.Models
{
    public class Focus
    {
        public int FocusID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Timeline> Timelines { get; set; }

        //public int UserID { get; set; }
        //public ApplicationUser User { get; set; }
    }
}