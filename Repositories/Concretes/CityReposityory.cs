using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;

namespace BusinessApp.Repositories.Concretes
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly AppDbContext _context;
        public CityRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}