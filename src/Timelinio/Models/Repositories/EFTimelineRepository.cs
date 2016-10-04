using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timelinio.Data;

namespace Timelinio.Models
{
    public class EFItemRepository : ITimelineRepository
    {

        ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Timeline> Timelines
        { get { return _context.Timelines; } }

        public Timeline Save(Timeline timeline)
        {
            _context.Timelines.Add(timeline);
            _context.SaveChanges();
            return timeline;
        }

        public Timeline Edit(Timeline timeline)
        {
            _context.Entry(timeline).State = EntityState.Modified;
            _context.SaveChanges();
            return timeline;
        }

        public void Remove(Timeline timeline)
        {
            _context.Timelines.Remove(timeline);
            _context.SaveChanges();
        }
    }
}