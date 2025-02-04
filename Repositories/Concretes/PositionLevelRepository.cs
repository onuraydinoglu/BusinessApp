using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;

namespace BusinessApp.Repositories.Concretes
{
  public class PositionLevelRepository : Repository<PositionLevel>, IPositionLevelRepository
  {
    private readonly AppDbContext _context;
    public PositionLevelRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }
  }
}