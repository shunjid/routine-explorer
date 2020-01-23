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

/*
http://localhost:5000/api/routine
body: 
{
    "id": 1,
    "nameOfFilesUploaded": "Spring 2020 Version-2",
    "statusOfPublish": true,
    "timeOfUpload": "2020-01-23T23:27:22.8211125"
}
response:
[
    {
        "id": 1,
        "roomNumber": "601AB",
        "courseCode": "CS312A",
        "teacher": "MAR",
        "dayOfWeek": "Saturday",
        "timeRange": "02:30-04:00",
        "status": null
    },
    {
        "id": 2,
        "roomNumber": "305AB",
        "courseCode": "ENG101A",
        "teacher": "SM",
        "dayOfWeek": "Tuesday",
        "timeRange": "10:00-11:30",
        "status": null
}]
*/

/*
http://localhost:5000/api/routine/GetRoutineByCourses
body:
{
	"subject01": "SWE422A",
	"subject02": null,
	"subject03": "SWE425A",
	"subject04": null,
	"subject05": null,
	"status" : {
			     "id": 1,
			     "nameOfFilesUploaded": "Spring 2020 Version-2",
			     "statusOfPublish": true,
			     "timeOfUpload": "2020-01-23T23:27:22.8211125"
			   }
}
response
[
{
        "id": 333,
        "roomNumber": "405AB",
        "courseCode": "SWE422A_LAB",
        "teacher": "LR",
        "dayOfWeek": "Sunday",
        "timeRange": "10:00-11:30",
        "status": null
    },
    {
        "id": 358,
        "roomNumber": "507MB",
        "courseCode": "SWE425A_LAB",
        "teacher": "ZI",
        "dayOfWeek": "Sunday",
        "timeRange": "04:00-05:30",
        "status": null
}]



*/