using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timelinio.Models;
using Timelinio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Timelinio.Controllers
{
    [Authorize]
    public class TimelinesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TimelinesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager = null)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: /<controller>/
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (_userManager != null)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var currentUser = await _userManager.FindByIdAsync(userId);
                return View(await _context.Timelines.Where(x => x.User.Id == currentUser.Id).Include(t => t.Focus).ToListAsync());
            }
            else
            {
                return View("Index", "Home");
            }
            //return View(await _context.Timelines.Include(t => t.Focus).ToListAsync());
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
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            timeline.User = currentUser;
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

        [HttpPost]
        public async Task<ActionResult> MyAjaxPOST()
        {
            var newFocus = new Focus { Name = Request.Form["Name"], Description = Request.Form["Description"] };
            //ViewBag.Message = "Your app description page.";
            //string temp = Request.Form["userName"];
            _context.Add(newFocus);
            await _context.SaveChangesAsync();

            return Json(newFocus);
        }
    }
}
