using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      var entities = await _context.Set<T>().ToListAsync();
      return entities;
    }

    public async Task<T> GetByIdAsync(int id)
    {
      var entity = await _context.Set<T>().FindAsync(id);
      if (entity is null)
      {
        throw new Exception($"{id} not found.");
      }
      return entity;
    }
    public async Task AddAsync(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var entity = await GetByIdAsync(id);
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
      throw new NotImplementedException();
    }
  }

}