using Microsoft.AspNetCore.Mvc;

namespace BusinessApp.Controllers
{
    public class JobsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}