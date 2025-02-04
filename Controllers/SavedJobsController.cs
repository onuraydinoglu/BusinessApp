using System.Security.Claims;
using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApp.Controllers
{
  public class SavedJobsController : Controller
  {
    private readonly ISavedJobRepository _savedJobRepository;

    public SavedJobsController(ISavedJobRepository savedJobRepository)
    {
      _savedJobRepository = savedJobRepository;
    }

    public async Task<IActionResult> CreateSavedJobs(int jobId)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }

      var isSaved = await _savedJobRepository.isSavedJobAsync(int.Parse(userId), jobId);

      if (isSaved)
      {
        TempData["ErrorMessage"] = "You have already saved this job.";
        return RedirectToAction("Index", "Jobs");
      }

      var savedJob = new SavedJob
      {
        UserId = int.Parse(userId),
        JobId = jobId
      };

      await _savedJobRepository.AddAsync(savedJob);
      return RedirectToAction("Index", "Jobs");
    }

    public async Task<IActionResult> DeleteSevedJobs(int jobId)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }

      var savedJobs = await _savedJobRepository.GetAllSavedJobsAsync(int.Parse(userId));
      var jobToDelete = savedJobs.FirstOrDefault(s => s.JobId == jobId);

      if (jobToDelete != null)
      {
        await _savedJobRepository.DeleteAsync(jobToDelete.Id);
      }

      return RedirectToAction("Index", "Jobs");
    }


  }
}