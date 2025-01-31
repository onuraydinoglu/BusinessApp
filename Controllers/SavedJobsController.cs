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

    public async Task<IActionResult> SavedJobs(int jobId)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }

      var isSaved = await _savedJobRepository.isSavedJobAsync(int.Parse(userId), jobId);

      if (isSaved)
      {
        {
          TempData["ErrorMessage"] = "You are already enrolled in this job.";
          return RedirectToAction("SavedJobs", "Profile", new { id = jobId });
        }
      }

      var savedJob = new SavedJob
      {
        UserId = int.Parse(userId),
        JobId = jobId
      };

      await _savedJobRepository.AddAsync(savedJob);
      return RedirectToAction("SavedJobs", "Profile", new { id = jobId });
    }
  }
}