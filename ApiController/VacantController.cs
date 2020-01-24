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