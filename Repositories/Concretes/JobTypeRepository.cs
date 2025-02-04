using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;

namespace BusinessApp.Repositories.Concretes
{
  public class JobTypeRepository : Repository<JobType>, IJobTypeRepository
  {
    private readonly AppDbContext _context;

    public JobTypeRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }
  }
}