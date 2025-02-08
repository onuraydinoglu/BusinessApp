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

        public async Task<ActionResult> Index()
        {
            var plans = await _planRepository.GetAllAsync();
            return View(plans);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Plan plan)
        {
            await _planRepository.AddAsync(plan);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var plan = await _planRepository.GetByIdAsync(id);
            return View(plan);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Plan plan)
        {
            await _planRepository.UpdateAsync(plan);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _planRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}