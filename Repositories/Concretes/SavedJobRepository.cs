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

    public async Task<IEnumerable<SavedJob>> GetAllSavedJobs(int userId)
    {
      var mySavedJobs = await _context.SavedJobs.Where(x => x.UserId == userId).ToListAsync();
      return mySavedJobs;
    }

    public async Task<bool> isSavedJobAsync(int userId, int jobId)
    {
      var savedJob = await _context.SavedJobs.AnyAsync(x => x.UserId == userId && x.JobId == jobId);
      return savedJob;
    }
  }
}