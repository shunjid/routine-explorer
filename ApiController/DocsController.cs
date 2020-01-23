using Microsoft.AspNetCore.Mvc;

namespace routine_explorer.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}