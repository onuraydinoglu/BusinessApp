using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;

namespace BusinessApp.Repositories.Concretes
{
  public class RemoteOptionRepository : Repository<RemoteOption>, IRemoteOptionRepository
  {
    private readonly AppDbContext _context;
    public RemoteOptionRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }
  }
}