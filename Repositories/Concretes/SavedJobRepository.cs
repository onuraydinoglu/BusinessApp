using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class SavedJobRepository : Repository<SavedJob>, ISavedJobRepository
  {
    private readonly AppDbContext _context;

    public SavedJobRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<IEnumerable<SavedJob>> GetAllSavedJobsAsync(int userId)
    {
      var mySavedJobs = await _context.SavedJobs
          .Include(x => x.User)
          .Include(x => x.Job).ThenInclude(x => x.Category)
          .Include(x => x.Job).ThenInclude(x => x.PositionLevel)
          .Include(x => x.Job).ThenInclude(x => x.JobType)
          .Include(x => x.Job).ThenInclude(x => x.RemoteOption)
          .Where(x => x.UserId == userId)
          .ToListAsync();

      return mySavedJobs;
    }

    public async Task<List<int>> GetAllUserAndJobAsync(int userId)
    {
      var mySavedJobs = await _context.SavedJobs.Where(x => x.UserId == userId).Select(x => x.JobId).ToListAsync();
      return mySavedJobs;
    }

    public async Task<bool> isSavedJobAsync(int userId, int jobId)
    {
      var savedJob = await _context.SavedJobs.AnyAsync(x => x.UserId == userId && x.JobId == jobId);
      return savedJob;
    }
  }
}