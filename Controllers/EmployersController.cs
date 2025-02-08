using System.Threading.Tasks;
using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApp.Controllers
{
    public class EmployersController : Controller
    {
        private readonly IPlanRepository _planRepository;

        public EmployersController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<IActionResult> Index()
        {
            var plans = await _planRepository.GetAllAsync();
            return View(plans);
        }
    }
}