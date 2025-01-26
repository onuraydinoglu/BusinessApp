using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class JobRepository : Repository<Job>, IJobRepository
  {
    private readonly AppDbContext _context;

    public JobRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Job>> GetAllJobsAsync()
    {
      var jobs = await _context.Jobs.Include(x => x.Category).Include(x => x.JobType).Include(x => x.User).ToListAsync();
      return jobs;
    }

    public async Task<List<string?>> GetAllLocationsAsync()
    {
      return await _context.Jobs
          .Select(j => j.Location)
          .Distinct()
          .ToListAsync();
    }

    public async Task<Job> GetByIdJobAsync(int? id)
    {
      var job = await _context.Jobs.Include(x => x.Category).Include(x => x.JobType).FirstOrDefaultAsync(x => x.Id == id);
      return job;
    }

    public async Task UpdateJobAsync(Job job)
    {
      var jb = await GetByIdJobAsync(job.Id);
      jb.Title = job.Title;
      jb.CategoryId = job.CategoryId;
      jb.CreatedDate = job.CreatedDate;
      jb.Description = job.Description;
      jb.IsActive = job.IsActive;
      jb.JobTypeId = job.JobTypeId;
      jb.Location = job.Location;
      jb.SalaryRange = job.SalaryRange;
      jb.JobTypeId = job.JobTypeId;
      jb.UserId = job.UserId;
      _context.Jobs.Update(jb);
      await _context.SaveChangesAsync();
    }
  }
}