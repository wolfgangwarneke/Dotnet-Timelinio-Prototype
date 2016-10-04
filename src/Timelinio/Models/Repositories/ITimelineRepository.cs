using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timelinio.Models
{
    public interface ITimelineRepository
    {
        IQueryable<Timeline> Timelines { get; }
        Timeline Save(Timeline timeline);
        Timeline Edit(Timeline timeline);
        void Remove(Timeline timeline);
    }
}