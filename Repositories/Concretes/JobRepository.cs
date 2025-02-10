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
      var jobs = await _context.Jobs.Include(x => x.Category).Include(x => x.City).Include(x => x.JobType).Include(x => x.Employer).Include(x => x.SavedJobs).Include(x => x.RemoteOption).Include(x => x.PositionLevel).Include(x => x.Specialization).ToListAsync();
      return jobs;
    }

    public async Task<List<Job>> GetAllUserAndJobAsync(int employerId)
    {
      var jobs = await _context.Jobs
          .Where(x => x.EmployerId == employerId)
          .Include(x => x.Category).Include(x => x.City).Include(x => x.JobType).Include(x => x.RemoteOption).Include(x => x.PositionLevel).Include(x => x.Specialization).ToListAsync();

      return jobs;
    }

    public async Task<Job> GetByIdJobAsync(int? id)
    {
      var job = await _context.Jobs.Include(x => x.Category).Include(x => x.City).Include(x => x.JobType).Include(x => x.Employer).Include(x => x.RemoteOption).Include(x => x.PositionLevel).Include(x => x.Specialization).FirstOrDefaultAsync(x => x.Id == id);
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
      jb.SalaryRange = job.SalaryRange;
      jb.JobTypeId = job.JobTypeId;
      jb.EmployerId = job.EmployerId;
      jb.RemoteOptionId = job.RemoteOptionId;
      jb.PositionLevelId = job.PositionLevelId;
      jb.CityId = job.CityId;
      jb.IsCompleted = job.IsCompleted;
      _context.Jobs.Update(jb);
      await _context.SaveChangesAsync();
    }
  }
}