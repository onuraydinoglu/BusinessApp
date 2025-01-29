using Microsoft.AspNetCore.Mvc;

namespace BusinessApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}