using System.Threading.Tasks;
using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApp.Controllers
{
    public class EmployersController : Controller
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployersController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }
        public async Task<IActionResult> Index()
        {
            var employers = await _employerRepository.GetAllAsync();
            return View(employers);
        }
    }
}