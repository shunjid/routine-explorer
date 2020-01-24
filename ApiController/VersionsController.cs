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
    public class VersionsController : Controller
    {
        private readonly DatabaseContext _context;

        public VersionsController(DatabaseContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                var allRoutineVersions = await _context.RoutineFileUploaderStatus.ToListAsync();
                return Json(allRoutineVersions);
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
        
        [HttpGet("GetLatestVersion")]
        public async Task<JsonResult> GetLatestVersion()
        {
            try
            {
                var allVersions = await _context.RoutineFileUploaderStatus.ToListAsync();
                return Json(allVersions.LastOrDefault());
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