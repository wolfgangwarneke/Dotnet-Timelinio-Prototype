using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timelinio.Models;
using Timelinio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Timelinio.Controllers
{
    public class TimelinesController : Controller
    {
        private readonly TimelineContext _context;

        public TimelinesController(TimelineContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Timelines.Include(t => t.Focus).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Timelines
                .Include(e => e.Events)
                .Include(f => f.Focus)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.TimelineID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Create()
        {
            PopulateFocusesDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Credits,FocusID,Title,Description,BeginDate,EndDate")] Timeline timeline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeline);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            PopulateFocusesDropDownList(timeline.FocusID);
            return View(timeline);
        }

        private void PopulateFocusesDropDownList(object selectedFocus = null)
        {
            var focusesQuery = from f in _context.Focuses
                                   orderby f.Name
                                   select f;
            ViewBag.FocusID = new SelectList(focusesQuery, "FocusID", "Name", selectedFocus);
        }
    }
}
