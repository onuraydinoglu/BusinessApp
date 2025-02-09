using System.Security.Claims;
using BusinessApp.Entities;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
    [Authorize(Roles = "Admin,Employer")]
    public class AdminJobsController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IJobTypeRepository _jobTypeRepository;
        private readonly IEmployerRepository _employerRepository;
        private readonly IRemoteOptionRepository _remoteOptionRepository;
        private readonly IPositionLevelRepository _positionLevelRepository;
        private readonly ISpecializationRepository _specializationRepository;
        private readonly ICityRepository _cityRepository;
        public AdminJobsController(IJobRepository jobRepository, ICategoryRepository categoryRepository, IJobTypeRepository jobTypeRepository, IEmployerRepository employerRepository, IRemoteOptionRepository remoteOptionRepository, IPositionLevelRepository positionLevelRepository, ICityRepository cityRepository, ISpecializationRepository specializationRepository)
        {
            _jobRepository = jobRepository;
            _categoryRepository = categoryRepository;
            _jobTypeRepository = jobTypeRepository;
            _employerRepository = employerRepository;
            _remoteOptionRepository = remoteOptionRepository;
            _positionLevelRepository = positionLevelRepository;
            _cityRepository = cityRepository;
            _specializationRepository = specializationRepository;
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
            ViewBag.Specializations = new SelectList(await _specializationRepository.GetAllAsync(), "Id", "Name");
            ViewBag.Cities = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name");

            if (User.IsInRole("Admin"))
            {
                // Admin ise tüm employer listesini dropdown olarak göster
                ViewBag.Employers = new SelectList(await _employerRepository.GetAllAsync(), "Id", "CompanyName");
            }

            else if (User.IsInRole("Employer"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId is null)
                {
                    return Unauthorized();
                }

                // Kullanıcının tüm şirketlerini getir
                var employers = await _employerRepository.GetEmployersByUserIdAsync(int.Parse(userId));
                if (employers is null || employers.Count == 0)
                {
                    return NotFound("Şirket bilgisi bulunamadı.");
                }

                ViewBag.Employers = new SelectList(employers, "Id", "CompanyName");
            }
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
            var job = await _jobRepository.GetByIdJobAsync(id);

            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            ViewBag.JobTypes = new SelectList(await _jobTypeRepository.GetAllAsync(), "Id", "Type");
            ViewBag.RemoteOptions = new SelectList(await _remoteOptionRepository.GetAllAsync(), "Id", "Name");
            ViewBag.PositionLevels = new SelectList(await _positionLevelRepository.GetAllAsync(), "Id", "Level");
            ViewBag.Employers = new SelectList(await _employerRepository.GetAllAsync(), "Id", "CompanyName");
            ViewBag.Specializations = new SelectList(await _specializationRepository.GetAllAsync(), "Id", "Name");
            ViewBag.Cities = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name");

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