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
      var jobs = await _context.Jobs.Include(x => x.Category).Include(x => x.JobType).ToListAsync();
      return jobs;
    }


    public async Task<Job> GetByIdJobAsync(int? id)
    {
      var job = await _context.Jobs.Include(x => x.Category).Include(x => x.JobType).FirstOrDefaultAsync(x => x.Id == id);
      return job;
    }

    public async Task UpdateJobAsync(Job job)
    {
      var jb = await GetByIdAsync(job.Id);
      jb.Title = job.Title;
      _context.Jobs.Update(jb);
      await _context.SaveChangesAsync();
    }
  }
}