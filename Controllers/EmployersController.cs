using System.Security.Claims;
using System.Threading.Tasks;
using BusinessApp.Entities;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
    public class EmployersController : Controller
    {
        private readonly IPlanRepository _planRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEmployerRepository _employerRepository;

        public EmployersController(IPlanRepository planRepository, IEmployerRepository employerRepository, ICategoryRepository categoryRepository)
        {
            _planRepository = planRepository;
            _employerRepository = employerRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");

            var plans = await _planRepository.GetAllAsync();
            return View(plans);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployer(Employer employer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Index", "Employers");
            }
            employer.UserId = int.Parse(userId);
            await _employerRepository.AddAsync(employer);
            return RedirectToAction("Index", "Employers");
        }
    }
}