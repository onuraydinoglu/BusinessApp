using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPlansController : Controller
    {
        private readonly IPlanRepository _planRepository;

        public AdminPlansController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<IActionResult> Index()
        {
            var plans = await _planRepository.GetAllAsync();
            return View(plans);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Plan plan)
        {
            await _planRepository.AddAsync(plan);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var plan = await _planRepository.GetByIdAsync(id);
            return View(plan);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Plan plan)
        {
            await _planRepository.UpdateAsync(plan);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _planRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}