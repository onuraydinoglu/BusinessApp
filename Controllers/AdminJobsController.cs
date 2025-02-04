using BusinessApp.Entities;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminJobsController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IJobTypeRepository _jobTypeRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IRemoteOptionRepository _remoteOptionRepository;
        private readonly IPositionLevelRepository _positionLevelRepository;
        public AdminJobsController(IJobRepository jobRepository, ICategoryRepository categoryRepository, IJobTypeRepository jobTypeRepository, IEmployerRepository employerRepository, IRemoteOptionRepository remoteOptionRepository, IPositionLevelRepository positionLevelRepository)
        {
            _jobRepository = jobRepository;
            _categoryRepository = categoryRepository;
            _jobTypeRepository = jobTypeRepository;
            _employerRepository = employerRepository;
            _remoteOptionRepository = remoteOptionRepository;
            _positionLevelRepository = positionLevelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobRepository.GetAllJobsAsync();
            return View(jobs);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            ViewBag.JobTypes = new SelectList(await _jobTypeRepository.GetAllAsync(), "Id", "Type");
            ViewBag.RemoteOptions = new SelectList(await _remoteOptionRepository.GetAllAsync(), "Id", "Name");
            ViewBag.PositionLevels = new SelectList(await _positionLevelRepository.GetAllAsync(), "Id", "Level");
            ViewBag.Employers = new SelectList(await _employerRepository.GetAllAsync(), "Id", "CompanyName");

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
            ViewBag.RemoteOptions = new SelectList(await _remoteOptionRepository.GetAllAsync(), "Id", "Name");
            ViewBag.PositionLevels = new SelectList(await _positionLevelRepository.GetAllAsync(), "Id", "Level");
            ViewBag.Employers = new SelectList(await _employerRepository.GetAllAsync(), "Id", "CompanyName");
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