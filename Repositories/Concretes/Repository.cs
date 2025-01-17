using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
      _context = context;
      _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      var entities = await _dbSet.ToListAsync();
      return entities;
    }

    public async Task<T> GetByIdAsync(int id)
    {
      var entity = await _dbSet.FindAsync(id);
      if (entity is null)
      {
        throw new Exception($"{id} not found.");
      }
      return entity;
    }
    public async Task AddAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
      await SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var entity = await GetByIdAsync(id);
      _dbSet.Remove(entity);
      await SaveAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      _dbSet.Update(entity);
      await SaveAsync();
    }

    public async Task SaveAsync()
    {
      await _context.SaveChangesAsync();
    }
  }

}