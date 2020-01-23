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
    public class VacantController : Controller
    {
        private readonly DatabaseContext _context;

        public VacantController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody]RoutineFileUploaderStatus status)
        {
            try
            {
                var vacancyByVersion = await _context.VacantRooms
                                                   .Where(vacancy => vacancy.Status == status)
                                                   .ToListAsync();
                return Json(vacancyByVersion);
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
http://localhost:5000/api/vacant
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
        "roomNumber": "505AB",
        "dayOfWeek": "Wednesday",
        "timeRange": "10:00-11:30",
        "status": null
    },
    {
        "id": 2,
        "roomNumber": "505AB",
        "dayOfWeek": "Wednesday",
        "timeRange": "08:30-10:00",
        "status": null
}]
*/