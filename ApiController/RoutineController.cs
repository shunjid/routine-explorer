using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using routine_explorer.Data;
using routine_explorer.Models;

namespace routine_explorer.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController : Controller
    {
        private readonly DatabaseContext _context;

        public RoutineController(DatabaseContext context)
        {
            _context = context;
        }

        private static string SanitizeTeacherInitial(string initial)
        {
            return string.IsNullOrEmpty(initial) ? "INVALID" : initial.ToUpper().Replace(" ", string.Empty);
        }
        
        private static string SanitizeCourseCodeInput(string courseCode)
        {
            if (string.IsNullOrEmpty(courseCode) ||  courseCode == "" || courseCode.Replace(" ", string.Empty) == "")
            {
                return "no course";
            }
            if (courseCode.ToUpper().StartsWith("AOL"))
            {
                return "AOL";
            }

            var courseInside = courseCode.ToUpper().Replace(" ", string.Empty);
            return courseInside;
        }
        
        [HttpGet]
        public async Task<JsonResult> Get([FromBody] RoutineFileUploaderStatus status)
        {
            try
            {
                var routineByVersion = await _context.Routine
                                                   .Where(routine => routine.Status == status)
                                                   .ToListAsync();
                return Json(routineByVersion);
            }
            catch (Exception e)
            {
                return Json(new ApiErrorModel
                {
                    ErrorMessage = e.Message,
                    StackTrace = e.StackTrace,
                    DateTime = DateTime.Now
                });
            }
        }

        [HttpPost("GetRoutineByCourses")]
        public async Task<JsonResult> GetRoutineByCourses([FromBody]Subjects subjects)
        {
            try
            {
                var schedule = await _context.Routine
                    .Where(r => r.Status.Id == subjects.Status.Id)
                    .OrderBy(d => d.Id)
                    .Where(x 
                        => x.CourseCode.StartsWith(SanitizeCourseCodeInput(subjects.Subject01)) 
                           || x.CourseCode.StartsWith(SanitizeCourseCodeInput(subjects.Subject02))
                           || x.CourseCode.StartsWith(SanitizeCourseCodeInput(subjects.Subject03))
                           || x.CourseCode.StartsWith(SanitizeCourseCodeInput(subjects.Subject04))
                           || x.CourseCode.StartsWith(SanitizeCourseCodeInput(subjects.Subject05)))
                    .ToListAsync();

                return Json(schedule);
            }
            catch (Exception e)
            {
                return Json(new ApiErrorModel
                {
                    ErrorMessage = e.Message,
                    StackTrace = e.StackTrace,
                    DateTime = DateTime.Now
                });
            }
        }

        [HttpPost("GetScheduleForTeacher")]
        public async Task<JsonResult> GetScheduleForTeacher([FromBody]TeacherAPI teacher)
        {
            try
            {
                var scheduleForTeacher = await _context.Routine
                                                    .Where(r => r.Status == teacher.Status)
                                                    .Where(t => t.Teacher == SanitizeTeacherInitial(teacher.TeacherInitial))
                                                    .ToListAsync();
                return Json(scheduleForTeacher);
            }
            catch (Exception e)
            {
                return Json(new ApiErrorModel
                {
                    ErrorMessage = e.Message,
                    StackTrace = e.StackTrace,
                    DateTime = DateTime.Now
                });
            }
        }
    }
}