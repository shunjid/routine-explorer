using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using routine_explorer.Data;
using routine_explorer.Models;

namespace routine_explorer.Controllers
{
    public class RoutinesController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<IdentityUser> _authToken;
        public RoutinesController(DatabaseContext context, UserManager<IdentityUser> authToken)
        {
            _context = context;
            _authToken = authToken;
        }
        
        private string _getCurrentlyLoggedInUser()
        {
            return _authToken.GetUserId(HttpContext.User);
        }

        // GET: Routines/Create
        public IActionResult Create()
        {
            if (_getCurrentlyLoggedInUser() == null)
            {
                return RedirectToAction("SetAuthorizationCookieImpersistent", "Credential");
            }
            return View();
        }
        
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            if (_getCurrentlyLoggedInUser() == null)
            {
                return RedirectToAction("SetAuthorizationCookieImpersistent", "Credential");
            }
            
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
                        var daysIndex = new List<int>();
                        string[] daysOfWeek = { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "List of" };
                        string[] timesOfADay = { "08:30-10:00", "10:00-11:30", "11:30-01:00", "01:00-02:30", "02:30-04:00", "04:00-05:30" };

                        for (var row = 1; row <= rowCount.Value; row++)
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


                        for (var x = 0; x < daysIndex.Count - 1; x++)
                        {
                            for (var y = daysIndex[x] + 1; y < daysIndex[x + 1]; y++)
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
                                                TimeRange = GetTimeStamp(timesOfADay, z),
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
                
                await _context.SaveChangesAsync();
                ViewBag.Signal = "File Uploaded Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index", "Home");
        }

        private static string GetTimeStamp(IReadOnlyList<string> arr, int cellValue)
        {
            switch (cellValue)
            {
                case 3:
                    return arr[0];
                case 6:
                    return arr[1];
                case 9:
                    return arr[2];
                case 12:
                    return arr[3];
                case 15:
                    return arr[4];
                case 18:
                    return arr[5];
                default:
                    return null;
            }
        }
    }
}
