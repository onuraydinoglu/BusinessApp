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
      var myApplications = await _context.Applications.Include(x => x.User).Include(x => x.Job).Where(x => x.UserId == userId).ToListAsync();
      return myApplications;
    }

    public async Task<bool> IsApplicationAsync(int userId, int jobId)
    {
      var applicationJob = await _context.Applications.AnyAsync(x => x.UserId == userId && x.JobId == jobId);
      return applicationJob;
    }
  }
}