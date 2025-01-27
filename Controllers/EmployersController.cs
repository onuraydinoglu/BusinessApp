using Microsoft.AspNetCore.Mvc;

namespace BusinessApp.Controllers
{
    public class EmployersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}