using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timelinio.Models;
using Timelinio.Data;
using Microsoft.EntityFrameworkCore;

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
            return View(await _context.Timelines.ToListAsync());
        }
    }
}
