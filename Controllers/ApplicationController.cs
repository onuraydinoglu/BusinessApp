using System.Security.Claims;
using System.Threading.Tasks;
using BusinessApp.Entities;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
  public class ApplicationController : Controller
  {
    private readonly IApplicationRepository _applicationRepository;
    public ApplicationController(IApplicationRepository applicationRepository)
    {
      _applicationRepository = applicationRepository;
    }

    public async Task<IActionResult> Create(int jobId)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }

      var isApplication = await _applicationRepository.IsApplicationAsync(int.Parse(userId), jobId);

      if (isApplication)
      {
        {
          TempData["ErrorMessage"] = "You are already enrolled in this job.";
          return RedirectToAction("Details", "Jobs", new { id = jobId });
        }
      }

      var application = new Application
      {
        UserId = int.Parse(userId),
        JobId = jobId
      };

      await _applicationRepository.AddAsync(application);
      return RedirectToAction("Details", "Jobs", new { id = jobId });
    }

  }
}