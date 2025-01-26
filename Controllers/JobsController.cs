using BusinessApp.Entities;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
    public class JobsController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IJobTypeRepository _jobTypeRepository;
        private readonly IUserRepository _userRepository;
        public JobsController(IJobRepository jobRepository, ICategoryRepository categoryRepository, IJobTypeRepository jobTypeRepository, IUserRepository userRepository)
        {
            _jobRepository = jobRepository;
            _categoryRepository = categoryRepository;
            _jobTypeRepository = jobTypeRepository;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            ViewBag.JobTypes = new SelectList(await _jobTypeRepository.GetAllAsync(), "Id", "Type");
            ViewBag.Locations = new SelectList(await _jobRepository.GetAllLocationsAsync(), null, null);
            var jobs = await _jobRepository.GetAllJobsAsync();
            var modelView = new JobViewModel
            {
                Jobs = jobs
            };
            return View(modelView);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            ViewBag.JobTypes = new SelectList(await _jobTypeRepository.GetAllAsync(), "Id", "Type");
            ViewBag.Users = new SelectList(await _userRepository.GetAllAsync(), "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Job job)
        {
            await _jobRepository.AddAsync(job);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var job = await _jobRepository.GetByIdJobAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            ViewBag.JobTypes = new SelectList(await _jobTypeRepository.GetAllAsync(), "Id", "Type");
            ViewBag.Users = new SelectList(await _userRepository.GetAllAsync(), "Id", "FullName");
            var job = await _jobRepository.GetByIdJobAsync(id);
            return View(job);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Job job)
        {
            await _jobRepository.UpdateJobAsync(job);
            return RedirectToAction("Index");
        }
    }
}