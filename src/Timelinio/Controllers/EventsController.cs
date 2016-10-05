using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Timelinio.Data;
using Timelinio.Models;
using System.Globalization;

namespace Timelinio.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var timelineContext = _context.Events.Include(c => c.Timeline);
            return View(await timelineContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["TimelineID"] = new SelectList(_context.Timelines, "TimelineID", "TimelineID");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,Date,Description,TimelineID,Title")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TimelineID"] = new SelectList(_context.Timelines, "TimelineID", "TimelineID", @event.TimelineID);
            return View(@event);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAJAX([Bind("Date,Description,TimelineID,Title")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return Json(@event);
            }
            //ViewData["TimelineID"] = new SelectList(_context.Timelines, "TimelineID", "Title", @event.TimelineID);
            return Json("ERROR - event was not added");
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["TimelineID"] = new SelectList(_context.Timelines, "TimelineID", "TimelineID", @event.TimelineID);
            return PartialView(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var questin = Request;
            Event @event = await _context.Events
                            .SingleOrDefaultAsync(x => x.EventID == id);
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    @event.Title = Request.Form["Title"];
                    @event.Description = Request.Form["Description"];
                    @event.Date = DateTime.ParseExact(Request.Form["Date"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return PartialView("EditConfirmed");
            }
            //ViewData["TimelineID"] = new SelectList(_context.Timelines, "TimelineID", "TimelineID", @event.TimelineID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return PartialView(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return PartialView("DeleteConfirmed");
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }

        public async Task<IActionResult> SendEventText(int id)
        {
            Event eventTextEvent = await _context.Events.SingleOrDefaultAsync(m => m.EventID == id);
            ViewData["eventTitle"] = eventTextEvent.Title;
            ViewData["eventDescription"] = eventTextEvent.Description;
            ViewData["eventDate"] = eventTextEvent.Date;
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendEventText(EventText newEventText)
        {
            newEventText.Send();
            return RedirectToAction("Index", "Timelines");
        }
    }
}
