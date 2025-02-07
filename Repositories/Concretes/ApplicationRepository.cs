using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class ApplicationRepository : Repository<Application>, IApplicationRepository
  {
    private readonly AppDbContext _context;
    public ApplicationRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Application>> GetAllApplicationsAsync(int userId)
    {
      var myApplications = await _context.Applications
          .Include(x => x.User)
          .Include(x => x.Job).ThenInclude(x => x.Category)
          .Include(x => x.Job).ThenInclude(x => x.PositionLevel)
          .Include(x => x.Job).ThenInclude(x => x.JobType)
          .Include(x => x.Job).ThenInclude(x => x.RemoteOption)
          .Where(x => x.UserId == userId)
          .ToListAsync();

      return myApplications;
    }

    public async Task<List<int>> GetAllUserAndJobAsync(int userId)
    {
      var IsApplicationAsync = await _context.Applications
          .Where(x => x.UserId == userId)
          .Select(x => x.JobId)
          .ToListAsync();

      return IsApplicationAsync;
    }

    public async Task<bool> IsApplicationAsync(int userId, int jobId)
    {
      var applicationJob = await _context.Applications.AnyAsync(x => x.UserId == userId && x.JobId == jobId);
      return applicationJob;
    }
  }
}