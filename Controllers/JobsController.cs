using System.Security.Claims;
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
        private readonly IEmployerRepository _employerRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ISavedJobRepository _savedJobRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IRemoteOptionRepository _remoteOptionRepository;
        private readonly IPositionLevelRepository _positionLevelRepository;
        public JobsController(IJobRepository jobRepository, ICategoryRepository categoryRepository, IJobTypeRepository jobTypeRepository, IEmployerRepository employerRepository, IUserRepository userRepository, ICityRepository cityRepository, ISavedJobRepository savedJobRepository, IApplicationRepository applicationRepository, IRemoteOptionRepository remoteOptionRepository, IPositionLevelRepository positionLevelRepository)
        {
            _jobRepository = jobRepository;
            _categoryRepository = categoryRepository;
            _jobTypeRepository = jobTypeRepository;
            _employerRepository = employerRepository;
            _userRepository = userRepository;
            _cityRepository = cityRepository;
            _savedJobRepository = savedJobRepository;
            _applicationRepository = applicationRepository;
            _remoteOptionRepository = remoteOptionRepository;
            _positionLevelRepository = positionLevelRepository;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await _jobRepository.GetAllJobsAsync();
            var jobTypes = await _jobTypeRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();
            var cities = await _cityRepository.GetAllAsync();
            var remoteOption = await _remoteOptionRepository.GetAllAsync();
            var positionLevel = await _positionLevelRepository.GetAllAsync();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var savedJobIds = new List<int>();

            if (userId != null)
            {
                var savedJobs = await _savedJobRepository.GetAllSavedJobsAsync(int.Parse(userId));
                savedJobIds = savedJobs.Select(s => s.JobId).ToList();
            }

            ViewBag.SavedJobIds = savedJobIds; // Kullanıcının kaydettiği iş ilanları ID'leri
            return View(new JobViewModel
            {
                Jobs = jobs,
                JobTypes = jobTypes,
                Categories = categories,
                Cities = cities,
                RemoteOptions = remoteOption,
                PositionLevels = positionLevel
            });
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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isApplication = false;

            if (userId != null)
            {
                isApplication = await _applicationRepository.IsApplicationAsync(int.Parse(userId), id);
            }

            ViewBag.IsApplication = isApplication;
            var user = userId != null ? await _userRepository.GetByIdUserAsync(int.Parse(userId)) : null;

            var viewModel = new JobViewModel
            {
                Job = job,
                User = user
            };

            return View(viewModel);
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