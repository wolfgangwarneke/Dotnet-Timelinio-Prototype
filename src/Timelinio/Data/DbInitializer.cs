using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Timelinio.Data;

namespace Timelinio.Models
{
    public static class DbInitializer
    {
        public static void Initialize(TimelineContext context)
        {
            context.Database.EnsureCreated();

           //  Look for any timelines.
            if (context.Focuses.Any())
                {
                    return;   // DB has been seeded
                }

            var focuses = new Focus[]
            {
            new Focus{Name="The Internet",Description="Focusing on the history of the Internet"},
            new Focus{Name="Me",Description="This is for timelines looking back on my life"}
            };
            foreach (Focus f in focuses)
            {
                context.Focuses.Add(f);
            }
            context.SaveChanges();

            var timelines = new Timeline[]
            {
            new Timeline{Title="Childhood Memories",Description="Looking back on my childhood",BeginDate=DateTime.Parse("1990-01-01"),EndDate=DateTime.Parse("2001-09-01"),FocusID=2},
            new Timeline{Title="High School",Description="My high school experience",BeginDate=DateTime.Parse("2001-09-01"),EndDate=DateTime.Parse("2005-06-15"),FocusID=2},
            new Timeline{Title="The Dotcom Boom",Description="The mainstream commercialization and impending bubble of eCommerce in the late 90's",BeginDate=DateTime.Parse("1995-01-01"),EndDate=DateTime.Parse("2001-09-01"),FocusID=1},
            new Timeline{Title="The Beginnings",Description="Early reseach and precursors to the Internet as we know it today",BeginDate=DateTime.Parse("1966-01-01"),EndDate=DateTime.Parse("1982-01-01"),FocusID=1}
            };
            foreach (Timeline t in timelines)
            {
                context.Timelines.Add(t);
            }
            context.SaveChanges();

            var events = new Event[]
            {
            new Event{TimelineID=1,Title="Watching the Matrix at in a hotel",Description="I remember watching the Matrix on the TV in a hotel and I was so hyped about it that I chugged a bunch of water and threw up! Ha.",Date=DateTime.Parse("1999-08-01")},
            new Event{TimelineID=1,Title="Getting my saxophone",Description="I remember opening up my saxophone case for the first time and how cool I thought it was",Date=DateTime.Parse("1998-06-10")},
            new Event{TimelineID=2,Title="Iraq War begins",Description="I remember being at a track fundraiser when the bombings over Iraq started and feeling weird that nobody was talking about it.",Date=DateTime.Parse("2003-03-20")},
            new Event{TimelineID=3,Title="Pets.com folds :(",Description="A prime example of a Dot-com bubble failure.  I will never forget that stupid sock-puppet mascot!",Date=DateTime.Parse("2000-11-01")},
            new Event{TimelineID=3,Title="GeoCities purchased by Yahoo!",Description="An example of the sort of deals going on at the time, Yahoo! purchased GeoCities for 3.57 billion",Date=DateTime.Parse("1999-01-01")},
            new Event{TimelineID=4,Title="ARPANET planning starts",Description="Bob Taylor and others start planning the Advanced Research Projects Agency Network",Date=DateTime.Parse("1966-01-01")},
            new Event{TimelineID=4,Title="Ethernet standar introduced",Description="",Date=DateTime.Parse("1980-01-01")}
            };
            foreach (Event e in events)
            {
                context.Events.Add(e);
            }
            context.SaveChanges();
        }
    }
}