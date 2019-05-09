using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using routine_explorer.Data;
using routine_explorer.Models;

namespace routine_explorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        public HomeController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var lastAddedId = _context.RoutineFileUploaderStatus.OrderByDescending(p => p.TimeOfUpload).FirstOrDefault();
            var courses = await _context.Routine
            .OrderBy(n => n.CourseCode)
            .Where(m => m.Status.Id == lastAddedId.Id)
            .Where(x => !x.CourseCode.EndsWith("LAB1") && !x.CourseCode.EndsWith("LAB2") && !x.CourseCode.EndsWith("LAB"))
            .Select(column => column.CourseCode)
            .Distinct()
            .ToListAsync();

            ViewBag.CoursesJSON = courses;
            return View(await _context.RoutineFileUploaderStatus.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
