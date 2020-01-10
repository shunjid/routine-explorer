using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using routine_explorer.Data;
using routine_explorer.Models;

namespace routine_explorer.Controllers
{
    public class RoutinesController : Controller
    {
        private readonly DatabaseContext _context;
        public RoutinesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Routines
        public async Task<IActionResult> Index()
        {
            var currentArabicMonthIndex = new HijriCalendar();
            ViewBag.arabicMonth = currentArabicMonthIndex.GetMonth(DateTime.Now) == 9 ? "Ramadan" : "Other";
            return View(await _context.Routine.Where(m => m.Status.Id == 0).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> TeachersRoutine(IFormCollection formFields){
            var currentArabicMonthIndex = new HijriCalendar();
            ViewBag.arabicMonth = currentArabicMonthIndex.GetMonth(DateTime.Now) == 9 ? "Ramadan" : "Other";

            return View("Index", await _context.Routine
            .Where(m => m.Status.Id == int.Parse(formFields["selected"]))
            .Where(t => t.Teacher == formFields["teacherInitial"]
            .ToString().ToUpper().Replace(" ", String.Empty)).ToListAsync());
        }   

        // GET: Routines/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routine = await _context.Routine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routine == null)
            {
                return NotFound();
            }

            return View(routine);
        }

        // GET: Routines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomNumber,CourseCode,Teacher,DayOfWeek,TimeRange")] Routine routine)
        {
            if (!ModelState.IsValid) return View(routine);
            _context.Add(routine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            var http = new HttpClient();
            var data = http.GetAsync("https://geoip-db.com/json/").Result.Content.ReadAsStringAsync().Result;
            var objectData = JObject.Parse(data);

            var audit = new Audit
            {
                UserIP = (string) objectData["IPv4"],
                UserLocation = (string) objectData["latitude"] + "," + (string) objectData["longitude"] + "," +
                               (string) objectData["city"],
                AreaAccessed = "/Create/FileUpload",
                ActionDateTime = DateTime.Now
            };

            var routine = new HashSet<Routine>();
            if (file == null || file.Length == 0 || !file.FileName.EndsWith("xlsx") || file.Length > 35000)
            {
                return RedirectToAction(nameof(Create));
            }

            var routineFileUploaderStatus = new RoutineFileUploaderStatus
            {
                NameOfFilesUploaded = file.FileName.Replace(".xlsx", ""),
                statusOfPublish = true,
                TimeOfUpload = DateTime.Now
            };

            var lastAddedId = _context.RoutineFileUploaderStatus.OrderByDescending(p => p.TimeOfUpload).FirstOrDefault();

            if (lastAddedId == null)
            {
                routineFileUploaderStatus.Id = 1;
            }
            else
            {
                routineFileUploaderStatus.Id = lastAddedId.Id + 1;
            }

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream).ConfigureAwait(false);

                    using (var package = new ExcelPackage(memoryStream))
                    {
                        var workSheet = package.Workbook.Worksheets.First();
                        var rowCount = workSheet.Dimension?.Rows;
                        var colCount = workSheet.Dimension?.Columns;
                        List<int> daysIndex = new List<int>();
                        string[] daysOfWeek = { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "List of" };
                        string[] timesOfADay = { "08:30-10:00", "10:00-11:30", "11:30-01:00", "01:00-02:30", "02:30-04:00", "04:00-05:30" };

                        for (int row = 1; row <= rowCount.Value; row++)
                        {
                            if (daysOfWeek.Any(workSheet.Cells[row, 1].Text.Contains))
                            {
                                daysIndex.Add(row);
                            }
                        }

                        daysIndex[0] += 2;
                        int z = 1;
                        string room = null;
                        string course = null;
                        string teacher = null;


                        for (int x = 0; x < daysIndex.Count - 1; x++)
                        {
                            for (int y = daysIndex[x] + 1; y < daysIndex[x + 1]; y++)
                            {
                                for (z = 1; z <= 18; z++)
                                {
                                    if ((z + 2) % 3 == 0)
                                    {
                                        room = workSheet.Cells[y, z].Text;
                                    }
                                    if ((z + 1) % 3 == 0)
                                    {
                                        course = workSheet.Cells[y, z].Text;
                                    }
                                    if (z % 3 == 0)
                                    {
                                        teacher = workSheet.Cells[y, z].Text;
                                        if (course.Replace(" ", String.Empty) == "") { }
                                        else
                                        {
                                            routine.Add(new Routine
                                            {
                                                RoomNumber = room.Replace(" ", String.Empty),
                                                CourseCode = course.Replace(" ", String.Empty),
                                                Teacher = teacher.Replace(" ", String.Empty),
                                                DayOfWeek = daysOfWeek[x],
                                                TimeRange = getTimeStamp(timesOfADay, z),
                                                Status = routineFileUploaderStatus
                                            });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (var item in routine)
                {
                    _context.Add(item);
                }
                _context.Add(audit);

                await _context.SaveChangesAsync();
                ViewBag.Signal = "File Uploaded Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Create));
        }

        private string getTimeStamp(string[] arr, int cellValue)
        {
            if (cellValue == 3) { return arr[0]; }
            if (cellValue == 6) { return arr[1]; }
            if (cellValue == 9) { return arr[2]; }
            if (cellValue == 12) { return arr[3]; }
            if (cellValue == 15) { return arr[4]; }
            if (cellValue == 18) { return arr[5]; }
            else { return null; }
        }



        // GET: Routines/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routine = await _context.Routine.FindAsync(id);
            if (routine == null)
            {
                return NotFound();
            }
            return View(routine);
        }

        // POST: Routines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomNumber,CourseCode,Teacher,DayOfWeek,TimeRange")] Routine routine)
        {
            if (id != routine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoutineExists(routine.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(routine);
        }

        // GET: Routines/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routine = await _context.Routine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routine == null)
            {
                return NotFound();
            }

            return View(routine);
        }

        // POST: Routines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routine = await _context.Routine.FindAsync(id);
            _context.Routine.Remove(routine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        private bool RoutineExists(int id)
        {
            return _context.Routine.Any(e => e.Id == id);
        }
    }
}
